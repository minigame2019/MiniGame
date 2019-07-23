using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default : InventoryItemBase
{
    public Default(int id, string name, Sprite image, string interactText, EItemType eItemType, float weight) : base(id, name, image, interactText, eItemType, weight)
    {
    }
    public Default()
    { }
}
