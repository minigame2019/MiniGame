using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : MonoBehaviour
{
    string Name;

    float Speed;

    public float RotationSpeed = 240.0f;

    public Inventory Inventory;

    public GameObject Hand;

    private HUD Hud;

    private Sprite sprite;

    public int Pressure;

    public void Talk(string content)
    {
        Hud.AddTalk(sprite,name,content);

    }

    public void Update()
    {
        //检测事件
        if (Pressure > 100)
        {
            // DO Something
        }
    }

    public List<string> ComplainContent = new List<string>();

}
