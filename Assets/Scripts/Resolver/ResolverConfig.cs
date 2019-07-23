using UnityEngine;
using System.Collections;

public class ResolverConfig : MonoBehaviour {

	void Start () 
	{
		ManagerResolver.Register<ISelectedManager>(SelectedManager.main);
		ManagerResolver.Register<IEventsManager>(EventsManager.main);
		ManagerResolver.Register<IUIManager>(UIManager.main);
    }
}
