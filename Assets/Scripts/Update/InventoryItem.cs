using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(InventoryItemBase item)
    {
        Item = item;
    }

    public InventoryEventArgs()
    {
    }
    public InventoryEventArgs(InventorySlot slot)
    {
        Slot = slot;
    }
    public InventoryEventArgs(InventorySlot slot,InventoryItemBase item)
    {
        Slot = slot;
        Item = item;
    }
    public InventorySlot Slot { get; set; }
    public InventoryItemBase Item { get; set; }
    public int InstanceId { get; set; }
}

