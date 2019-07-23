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

    public void UpdatePersonCard()
    {
        Transform personCards = transform.Find("PersonCards");


    }

    int columns = 3;
    private void Inventory_SlotAdded(object sender,InventoryEventArgs inventoryEventArgs)
    {
        Transform personCards = transform.Find("PersonCards");
        foreach (Transform personCard in personCards)
        {
            Transform invTrans = personCard.GetChild(1).GetChild(1).GetChild(0).GetChild(0);

        }


        Transform inventoryPanel = transform.Find("PersonCard_0");
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

    private const float TalkTime = 3.0f;
    private float TalkLastTime = TalkTime;

    public void Update()
    {
        TalkLastTime -= Time.deltaTime;
        if (TalkLastTime <= 0)
        {
            Talk toTalk = AllTalk.Pop();
            TalkUpdate(toTalk);
            TalkLastTime = TalkTime;
        }
    }

    public class Talk
    {
        public Sprite sprite;
        public string name;
        public string content;

        public Talk(Sprite s, string n,string c)
        {
            sprite = s;
            name = n;
            content = c;
        }
    }
    Stack<Talk> AllTalk = new Stack<Talk>();
    public void AddTalk(Sprite sprite, string name, string content)
    {
        AllTalk.Push(new Talk(sprite, name, content));
    }


    public void TalkUpdate(Talk talk)
    {
        Sprite sprite = talk.sprite;
        string name = talk.name;
        string content = talk.content;
        Transform talkPanel = transform.Find("UTalkPanel");
        Transform con = talkPanel.Find("Text");
        Text text = con.GetComponent<Text>();
        text.text = content;

        Transform nameLabel = talkPanel.Find("Actor_Label");
        Text text1 = nameLabel.GetComponent<Text>();
        text1.text = name;

        Transform img = talkPanel.Find("ActorImage");
        Image i = img.GetComponent<Image>();
        i.sprite = sprite;
    }
}
