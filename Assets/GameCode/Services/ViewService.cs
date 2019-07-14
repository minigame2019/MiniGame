using UnityEngine;
using System.Collections;
using Entitas;
public interface IViewService : IComponent
{
    IViewController LoadAsset(Contexts contexts, IEntity entity, string path);
}

public class ViewService : IViewService
{
    public IViewController LoadAsset(Contexts contexts,IEntity entity,string path)
    {
        var viewGo = GameObject.Instantiate(Resources.Load<GameObject>(path));
        if (viewGo == null) return null;
        var viewController = viewGo.GetComponent<IViewController>();
        if (viewController != null) viewController.InitializeView(contexts, entity);
        return viewController;
    }
}