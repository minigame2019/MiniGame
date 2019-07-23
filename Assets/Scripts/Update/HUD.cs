using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Inventory Inventory;

    public GameObject MessagePanel;

    public bool ShowMiniMap = true;

	// Use this for initialization
	void Start () {

        var miniMap = transform.Find("Minimap");

        miniMap.gameObject.SetActive(ShowMiniMap);

        Inventory.ItemAdded += Inventory_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
        Inventory.SlotAdded += Inventory_SlotAdded;
        Inventory.SlotRemoved += Inventory_SlotRemoved;

        
	}

    private void UpdateSlot(GameObject obj)
    {
        InventoryComponent inventoryComponent = obj.GetComponent<InventoryComponent>();
        InventorySlot slot = inventoryComponent.inventorySlot;
        Transform trans = obj.transform;
        Transform imageTransform = trans.GetChild(0).GetChild(0);
        Transform textTransform = trans.GetChild(0).GetChild(1);
        Image image = imageTransform.GetComponent<Image>();
        Text txtCount = textTransform.GetComponent<Text>();
        ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
        image.enabled = true;
        image.sprite = slot.Content.Image;

        int itemCount = slot.Count;
        if (itemCount > 1)
            txtCount.text = itemCount.ToString();
        else
            txtCount.text = "";
        slot.RecentChange = false;
    }

    int columns = 3;
    private void Inventory_SlotAdded(object sender,InventoryEventArgs inventoryEventArgs)
    {
        Transform inventoryPanel = transform.Find("BackPackScrollView");
        inventoryPanel = inventoryPanel.GetChild(0).GetChild(0);
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
    private void Inventory_SlotRemoved(object sender,InventoryEventArgs inventoryEventArgs)
    {
        Transform inventoryPanel = transform.Find("BackPackScrollView");
        inventoryPanel = inventoryPanel.GetChild(0).GetChild(0);
        foreach (Transform slot in inventoryPanel)
        {
            if (slot.GetComponent<InventoryComponent>().inventorySlot.IsEmpty)
            {
                slot.parent = null;
                Destroy(slot.gameObject);
            }
        }
    }

    private void Inventory_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("BackPackScrollView");
        inventoryPanel = inventoryPanel.GetChild(0).GetChild(0);
        foreach (Transform slot in inventoryPanel)
        {
            // Border... Image
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Transform textTransform = slot.GetChild(0).GetChild(1);
            Image image = imageTransform.GetComponent<Image>();
            Text txtCount = textTransform.GetComponent<Text>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            if(e.Item.Slot.RecentChange)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                int itemCount = e.Item.Slot.Count;
                if (itemCount > 1)
                    txtCount.text = itemCount.ToString();
                else
                    txtCount.text = "";
                         
                // Store a reference to the item
                itemDragHandler.Item = e.Item;
                e.Item.Slot.RecentChange = false;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("BackPackScrollView");
        inventoryPanel = inventoryPanel.GetChild(0).GetChild(0);
        foreach (Transform slot in inventoryPanel)
        {
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Transform textTransform = slot.GetChild(0).GetChild(1);

            Image image = imageTransform.GetComponent<Image>();
            Text txtCount = textTransform.GetComponent<Text>();

            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            // We found the item in the UI
            if (itemDragHandler.Item == null)
                continue;

            // Found the slot to remove from
            if(e.Item.Slot.RecentChange)
            {
                int itemCount = e.Item.Slot.Count;
                itemDragHandler.Item = e.Item.Slot.Content;

                if(itemCount < 2)
                {
                    txtCount.text = "";
                }
                else
                {
                    txtCount.text = itemCount.ToString();
                }

                if(itemCount == 0)
                {
                    image.enabled = false;
                    image.sprite = null;
                }
                e.Item.Slot.RecentChange = false;
            }
           
        }
    }

    private bool mIsMessagePanelOpened = false;

    public bool IsMessagePanelOpened
    {
        get { return mIsMessagePanelOpened; }
    }

    public void OpenMessagePanel(InteractableItemBase item)
    {
        MessagePanel.SetActive(true);

        Text mpText = MessagePanel.transform.Find("Text").GetComponent<Text>();
        mpText.text = item.InteractText;
        
        mIsMessagePanelOpened = true;
    }

    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true);

        Text mpText = MessagePanel.transform.Find("Text").GetComponent<Text>();
        mpText.text = text;

        mIsMessagePanelOpened = true;
    }

    public void CloseMessagePanel()
    {
        MessagePanel.SetActive(false);

        mIsMessagePanelOpened = false;
    }

    public void Update()
    {

    }
}
