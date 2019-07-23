using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIPersonCard : MonoBehaviour
{
    Inventory Inventory;
    //Player  


    // Use this for initialization
    void Start()
    {
        Inventory.ItemAdded += Inventory_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
        Inventory.SlotAdded += Inventory_SlotAdded;
        Inventory.SlotRemoved += Inventory_SlotRemoved;
        //player.AttributeChanged += Player_AttributeChanged;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Inventory_ItemAdded(object sender, InventoryEventArgs inventoryEventArgs)
    {
        Transform inventoryPanel = transform.Find("Content").Find("Inventory");
        inventoryPanel = inventoryPanel.GetChild(0).GetChild(0);
        foreach (Transform slot in inventoryPanel)
        {
            // Border... Image
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Transform textTransform = slot.GetChild(0).GetChild(1);
            Image image = imageTransform.GetComponent<Image>();
            Text txtCount = textTransform.GetComponent<Text>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            InventoryComponent inv = slot.GetComponent<InventoryComponent>();
            if (inv.inventorySlot.RecentChange)
            {
                image.enabled = true;
                image.sprite = inv.inventorySlot.Content.Image;

                int itemCount = inv.inventorySlot.Count;
                if (itemCount > 1)
                    txtCount.text = itemCount.ToString();
                else
                    txtCount.text = "";
                inv.inventorySlot.RecentChange = false;
            }
        }
    }

    void Inventory_ItemRemoved(object sender, InventoryEventArgs inventoryEventArgs)
    {
        Transform inventoryPanel = transform.Find("Content").Find("Inventory");
        inventoryPanel = inventoryPanel.GetChild(0).GetChild(0);
        foreach (Transform slot in inventoryPanel)
        {
            // Border... Image
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Transform textTransform = slot.GetChild(0).GetChild(1);
            Image image = imageTransform.GetComponent<Image>();
            Text txtCount = textTransform.GetComponent<Text>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            InventoryComponent inv = slot.GetComponent<InventoryComponent>();
            if (inv.inventorySlot.RecentChange)
            {
                image.enabled = true;
                image.sprite = inventoryEventArgs.Item.Image;

                int itemCount = inventoryEventArgs.Item.Slot.Count;
                if (itemCount > 1)
                    txtCount.text = itemCount.ToString();
                else
                    txtCount.text = "";

                // Store a reference to the item
                //itemDragHandler.Item ;
                // TODO : fix this bug above
                inv.inventorySlot.RecentChange = false;
            }
        }
    }

    void Inventory_SlotAdded(object sender, InventoryEventArgs inventoryEventArgs)
    {
        Transform inventoryPanel = transform.Find("Content").Find("Inventory");
        inventoryPanel = inventoryPanel.GetChild(0).GetChild(0);
        foreach (Transform slotTrans in inventoryPanel)
        {
            GameObject toAdd = Instantiate(Resources.Load("Slot_1") as GameObject);
            InventoryComponent i = toAdd.AddComponent<InventoryComponent>();
            i.inventorySlot = inventoryEventArgs.Slot;
            toAdd.transform.parent = inventoryPanel.transform;

            Transform imageTransform = toAdd.transform.GetChild(0).GetChild(0);
            Transform textTransform = toAdd.transform.GetChild(0).GetChild(1);
            Image image = imageTransform.GetComponent<Image>();
            Text txtCount = textTransform.GetComponent<Text>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            image.enabled = true;
            image.sprite = inventoryEventArgs.Item.Image;

            int itemCount = inventoryEventArgs.Item.Slot.Count;
            if (itemCount > 1)
                txtCount.text = itemCount.ToString();
            else
                txtCount.text = "";

            // Store a reference to the item
            itemDragHandler.Item = inventoryEventArgs.Item;
            inventoryEventArgs.Item.Slot.RecentChange = false;
        }        
    }

    void Inventory_SlotRemoved(object sender, InventoryEventArgs inventoryEventArgs)
    {
        Transform inventoryPanel = transform.Find("Content").Find("Inventory");
        inventoryPanel = inventoryPanel.GetChild(0).GetChild(0);
        foreach (Transform slotTrans in inventoryPanel)
        {
            if (slotTrans.GetComponent<InventoryComponent>().inventorySlot.IsEmpty)
            {
                slotTrans.parent = null;
                Destroy(slotTrans.gameObject);
           }      
        }
    }


}
