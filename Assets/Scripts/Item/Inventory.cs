using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public float MaxWeight = 100;
    
    private int slotCount = 0;
    private IList<InventorySlot> mSlots = new List<InventorySlot>();
    public IList<InventorySlot> MSlots { get { return mSlots; } }
    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;
    public event EventHandler<InventoryEventArgs> ItemUsed;
    public event EventHandler<InventoryEventArgs> SlotAdded;
    public event EventHandler<InventoryEventArgs> SlotRemoved;

    public float CurrentWeight
    {
        get
        {
            float output = 0;

            foreach (InventorySlot w in mSlots)
            {
                if (w.Count != 0)
                {
                    output += w.Count * w.Content.Weight;

                }
            }
            return output;
        }
    }

    public Inventory()
    {       
    }

    private InventorySlot FindStackableSlot(InventoryItemBase item)
    {
        foreach (InventorySlot slot in mSlots)
        {
            if (slot.IsStackable(item))
                return slot;
        }
        return null;
    }

    public int GetItemCount(InteractableItemBase item)
    {
        foreach (InventorySlot slot in mSlots)
        {
            if (slot.Content == null)
                break;

            if (slot.Content.Name == item.Name)
            {
                return slot.Count;
            }
        }
        return 0;
    }

    private InventorySlot FindNextEmptySlot()
    {
        foreach (InventorySlot slot in mSlots)
        {
            if (slot.IsEmpty)
                return slot;
        }
        return null;
    }

    public void AddItem(InventoryItemBase item)
    {
        if (CurrentWeight + item.Weight > this.MaxWeight)
        {
            return;
        }
        InventorySlot freeSlot = FindStackableSlot(item);
        if (freeSlot == null)
        {
            freeSlot = FindNextEmptySlot();
        }
        if (freeSlot != null)
        {
            freeSlot.AddItem(item,1);
            if (ItemAdded != null)
            {
                ItemAdded(this, new InventoryEventArgs(item));
            }
            RemoveEmptySlot();
        }
        else
        {
            InventorySlot inv = new InventorySlot();
            inv.RecentChange = true;
            mSlots.Add(inv);
            inv.AddItem(item,1);
            if(SlotAdded != null)
            {
                SlotAdded(this, new InventoryEventArgs(inv,item));
            }
        }
    }
    private void AddEmptySlot()
    {
        mSlots.Add(new InventorySlot());

    }

    private void RemoveEmptySlot()
    {
        foreach (InventorySlot inventorySlot in this.mSlots)
        {
            if (inventorySlot.IsEmpty)
            {
                mSlots.Remove(inventorySlot);
            }
        }
    }

    internal void UseItem(InventoryItemBase item)
    {
        if (ItemUsed != null)
        {
            ItemUsed(this, new InventoryEventArgs(item));
        }

        item.OnUse();
    }

    public void RemoveItem(InventoryItemBase item)
    {
        foreach (InventorySlot slot in mSlots)
        {
            if (slot.Remove(item,1))
            {
                if (slot.IsEmpty)
                {
                    mSlots.Remove(slot);
                    SlotRemoved(this,new InventoryEventArgs());
                    break;

                }
                if (ItemRemoved != null)
                {
                    ItemRemoved(this, new InventoryEventArgs(item));
                }
                break;
            }

        }
    }
}
