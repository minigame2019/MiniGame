using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItemType
{
    Default,
    Consumable,
    Weapon
}

public class InteractableItemBase : MonoBehaviour
{
    public int ID;

    public string Name;

    public Sprite Image;

    public string InteractText = "Press F to pickup the item";

    public EItemType ItemType;

    public float Weight= 1;

    public InteractableItemBase(int id,string name,Sprite image,string interactText, EItemType eItemType,float weight)
    {
        this.ID = id;
        Name = name;
        Image = image;
        InteractText = interactText;
        ItemType = eItemType;
        Weight = weight;
    }

    public InteractableItemBase()
    {

    }
    public virtual void OnInteractAnimation(Animator animator)
    {
        animator.SetTrigger("tr_pickup");
    }

    public virtual void OnInteract()
    {
    }

    public virtual bool CanInteract(Collider other)
    {
        return true;   
    }

    public virtual bool ContinueInteract()
    {
        return false;
    }
}

public class InventoryItemBase : InteractableItemBase
{
    public InventoryItemBase(int id, string name, Sprite image, string interactText, EItemType eItemType, float weight):base(id,name,image,interactText,eItemType,weight)
    {
    }

    public InventoryItemBase()
    {

    }
    public InventorySlot Slot
    {
        get; set;
    }

    public virtual void OnUse()
    {
        transform.localPosition = PickPosition;
        transform.localEulerAngles = PickRotation;
    }

    public virtual void OnDrop()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
            gameObject.transform.eulerAngles = DropRotation;
        }
    }

    public virtual void OnPickup()
    {
        Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.SetActive(false);
        
    }

    public Vector3 PickPosition;

    public Vector3 PickRotation;

    public Vector3 DropRotation;

    public bool UseItemAfterPickup = false;

    public static bool operator == (InventoryItemBase i1,InventoryItemBase i2)
    {
        if (object.Equals(i1,null) || object.Equals(i2,null))
        {
            return object.Equals(i2,i1);
        }
        return i1.Name == i2.Name;
    }
    public static bool operator !=(InventoryItemBase i1, InventoryItemBase i2)
    {
        return !(i1 == i2);
    }
}
