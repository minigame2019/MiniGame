using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectedManager : MonoBehaviour, ISelectedManager
{
    private List<PlayerController> SelectedActiveObjects = new List<PlayerController>();

    private List<PlayerController> SelectedObjects = new List<PlayerController>();

    private List<List<PlayerController>> Group = new List<List<PlayerController>>();

    public static SelectedManager main;

    public int OverlayWidth
    {
        get;
        private set;
    }

    public void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            Group.Add(new List<PlayerController>());
        }

        main = this;
        OverlayWidth = 80;
    }

    public void AddObject(PlayerController obj)
    {
        
        if (!SelectedObjects.Contains(obj))
        {
            if (obj.gameObject.layer == 9)
            {
                SelectedActiveObjects.Add((PlayerController)obj);
            }
            SelectedObjects.Add(obj);
            obj.SetSelected();
        }
    }

    public void DeselectAll()
    {
        foreach (PlayerController obj in SelectedObjects)
        {
            obj.SetDeselected();
        }

        SelectedObjects.Clear();
        SelectedActiveObjects.Clear();
    }

    public void DeselectObject(PlayerController obj)
    {
        SelectedActiveObjects.Remove(obj);
        obj.SetDeselected();
        SelectedObjects.Remove(obj);
    }

    /*
    public void GiveOrder(Order order)
    {
        foreach (IOrderable unit in SelectedActiveObjects)
        {
            unit.GiveOrder(order);
        }
    }
    */

    public void AddUnitsToGroup(int groupNumber)
    {
        Group[groupNumber].Clear();
        foreach (PlayerController obj in SelectedObjects)
        {
            Group[groupNumber].Add(obj);

        }
    }

    public void SelectGroup(int groupNumber)
    {
        DeselectAll();
        foreach (PlayerController obj in Group[groupNumber])
        {
            AddObject(obj);
        }
    }

    public int ActiveObjectsCount()
    {
        return SelectedActiveObjects.Count;
    }

    public PlayerController FirstActiveObject()
    {
        return SelectedActiveObjects[0];
    }

    public List<PlayerController> ActiveObjectList()
    {
        return SelectedActiveObjects;
    }

    public bool IsObjectSelected(GameObject obj)
    {
        return SelectedObjects.Contains(obj.GetComponent<PlayerController>());
    }
}
