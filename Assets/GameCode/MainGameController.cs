using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoSingleton<MainGameController>
{
    public MapSystem _mapSystem;
    public CharacterSystem _characterSystem;
    public ItemSystem _itemSystem;
    public PoolManager _poolManager;

    int count = 0;
    void Awake()
    {
        return;
        this._mapSystem = new MapSystem();
        this._characterSystem = new CharacterSystem();
        this._itemSystem = new ItemSystem();
        this._poolManager = PoolManager.Instance;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        return;
        if (Input.GetKeyDown("1"))
        {
            bag.AddItem(wood);
        }
        if (Input.GetKeyDown("2"))
        {
            bag.AddItem(iron);
        }
        if (Input.GetKeyDown("3"))
        {
            bag.AddItem(axe);
        }
        if (Input.GetKeyDown("4"))
        {
            bag.RemoveItem(wood);
        }
        if (Input.GetKeyDown("5"))
        {
            bag.RemoveItem(iron);
        }
        if (Input.GetKeyDown("6"))
        {
            bag.RemoveItem(axe);
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log(bag.ToString());
        }

    }

    private BackPack bag = new BackPack(500);

    Material wood = new Material(1,"wood",1,Item.ItemType.Material,"Wood Desc","Wood");
    Material iron = new Material(2, "iron", 2, Item.ItemType.Material, "Iron Desc", "Iron");
    Equipment axe = new Equipment(3, "axe", 10, Item.ItemType.Equipment, "Axe Desc", "Axe", 20, 1, 1, 100);

}
