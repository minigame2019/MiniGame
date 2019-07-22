using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : InventoryItemBase, IDamageSource,IDurability
{
    [Range(1, 100)]
    public int DamagePerHit = 20;
    public int MaxDurability = 100;
    public int CurrentDurability = 100;

    public int GetDamagePerHit()
    {
        return DamagePerHit;
    }

    public override void OnUse()
    {
        base.OnUse();
    }

    public void TakeDurability(int num)
    {
        this.CurrentDurability -= num;
        if (this.CurrentDurability <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
