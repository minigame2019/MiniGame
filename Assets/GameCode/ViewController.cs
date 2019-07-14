using UnityEngine;
using System.Collections;
using Entitas;
public interface IViewController
{
    Vector3 Position { get; set; }
    Vector3 Scale { get; set; }
    bool Active { get; set; }
    void InitializeView(Contexts contexts, IEntity Entity);
    void DestroyView();
}

public class ViewController : MonoBehaviour, IViewController
{
    protected Contexts _contexts;
    protected GameEntity _entity;

    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public Vector3 Scale
    {
        get { return transform.localScale; }
        set { transform.localScale = value; }
    }// as above but with tranform.localScale

    public bool Active { get { return gameObject.activeSelf; } set { gameObject.SetActive(value); } }

    public void InitializeView(Contexts contexts, IEntity Entity)
    {
        _contexts = contexts;
        _entity = (GameEntity) Entity;
    }

    public void DestroyView()
    {
        Object.Destroy(this);
    }
}

