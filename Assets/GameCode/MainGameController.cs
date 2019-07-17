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
        if (Input.GetMouseButtonDown(0))
        {
            spawn();
        }
    }

    void spawn()
    {
        GameObject temp = PoolManager.Instance.Spawn("Bullet");
        temp.transform.SetParent(transform);
        temp.transform.localPosition = new Vector3(count, count, count);
        count++;
    }
}
