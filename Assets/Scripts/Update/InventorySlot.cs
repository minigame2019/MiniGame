using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    public InventorySlot inventorySlot;
}



public class InventorySlot
{
    private Stack<InventoryItemBase> mItemStack = new Stack<InventoryItemBase>();

    public InventoryItemBase Content { get; set; }
    public int Count { get; set; }

    public bool RecentChange = false;

    public InventorySlot()
    {
        Content = null;
        Count = 0;
    }

    public void AddItem(InventoryItemBase item,int num)
    {
        if (this.Content == null)
        {
            Content = item;
            Content.Slot = this;
        }
        //mItemStack.Push(item);
        Count += num;
        RecentChange = true;
    }

    public bool IsStackable(InventoryItemBase item)
    {
        if (item.ItemType == EItemType.Weapon)
        {
            return false;
        }
        if (IsEmpty)
            return false;

        if (Content == item)
            return true;
        return false;
    }

    public bool IsEmpty
    {
        get { return Count == 0; }
    }

    public bool Remove(InventoryItemBase item,int num)
    {
        if (IsEmpty)
            return false;

        if (Content == item)
        {
            Count -= num;
            // TODO: Count < 0
            Count = Count < 0 ? 0 : Count;
            RecentChange = true;
            return true;
        }
        return false;
    }
}
