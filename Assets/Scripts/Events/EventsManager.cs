using UnityEngine;
using System.Collections;
using System;

//Delegates
public delegate void MouseActions(object sender, MouseEventArgs e);

public partial class EventsManager : MonoBehaviour, IEventsManager {
	
	//--------------------------EVENTS-------------------------	
	public event MouseActions MouseClick;
	//-----------------------------------------------------------------------
		
	//--------------------------SINGLETON--------------
	public static EventsManager main;
	//---------------------------------------------------	
	
	void Awake()
	{
		main = this;
		
		MouseClick += DoubleClickCheck;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{		
		CheckMouseClicks ();			
	}
}
