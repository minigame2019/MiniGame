using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

public class UIManager : MonoBehaviour, IUIManager {
	
	//Singleton
	public static UIManager main;
	
	//Width of GUI menu
	private float m_GuiWidth;
	
	//Action Variables
	private HoverOver hoverOver = HoverOver.Land;
	private GameObject currentObject;
	private ISelectedManager m_SelectedManager;

	private Action m_CallBackFunction;
	private InteractableItemBase m_ItemBeingPlaced;
	private GameObject m_ObjectBeingPlaced;
	private bool m_PositionValid = true;
	private bool m_Placed = false;
	
	void Awake()
	{
		main = this;
    }

	// Use this for initialization
	void Start () 
	{
        m_SelectedManager = ManagerResolver.Resolve<ISelectedManager>();
		IEventsManager eventsManager = ManagerResolver.Resolve<IEventsManager>();
		eventsManager.MouseClick += ButtonClickedHandler;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ModeNormalBehaviour ();
	}
	
	private void ModeNormalBehaviour()
	{
		hoverOver = HoverOver.Land;
		InteractionState interactionState = InteractionState.Nothing;
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;		
			
		if (Physics.Raycast (ray, out hit, Mathf.Infinity, ~(1 << 16)))
		{
			currentObject = hit.collider.gameObject;
			switch (hit.collider.gameObject.layer)
			{
			case 10:
				//Enemy unit
				hoverOver = HoverOver.EnemyUnit;
				break;
					
			case 9:
				// Player
				hoverOver = HoverOver.FriendlyUnit;
				break;
			}				
		}	
	}
	
	//----------------------Mouse Button Handler------------------------------------
	private void ButtonClickedHandler(object sender, MouseEventArgs e)
	{
            Debug.Log("ButtonClickedHandler");
			e.Command ();
	}
	
	//------------------------Mouse Button Commands--------------------------------------------
	public void LeftButton_SingleClickDown(MouseEventArgs e)
	{
	    //We've left clicked, what have we left clicked on?
		int currentObjLayer = currentObject.layer;
			
		if (currentObjLayer == 9)
		{
            Debug.Log("UIManager -- LeftButton_SingleClickDown");
            //Debug.Log("UIManager -- LeftButton_SingleClickDown");
            if (m_SelectedManager.IsObjectSelected(currentObject))
			{
                
            }
		}
	}
	
	public void LeftButton_DoubleClickDown(MouseEventArgs e)
	{
		if (currentObject.layer == 8)
		{
			//Select all units of that type on screen			
		}
	}
	
	public void LeftButton_SingleClickUp(MouseEventArgs e)
	{
			if (m_Placed)
			{
				m_Placed = false;
				return;
			}
			
			//We've left clicked, have we left clicked on a unit?
			int currentObjLayer = currentObject.layer;
			if (/*!m_GuiManager.Dragging && */currentObjLayer == 9)
			{			
				m_SelectedManager.AddObject (currentObject.GetComponent<PlayerController>());
			}
	}
	
	public void RightButton_SingleClick(MouseEventArgs e)
	{
			int currentObjLayer = currentObject.layer;
			if (currentObjLayer == 11)
			{
                //Normal terrian -> Move
                IAstarAI ai = m_SelectedManager.;
                for (int i = 0; i < ais.Length; i++)
                {
                    if (ais[i] != null) ais[i].SearchPath();
                }
            }
            if (currentObjLayer == 10)
            {
                //Enenmy Unit -> Attack
            }
            else
            {
    
            }
	}
	
	public void RightButton_DoubleClick(MouseEventArgs e)
	{
		
	}
	
	public void MiddleButton_SingleClick(MouseEventArgs e)
	{
		
	}
	
	public void MiddleButton_DoubleClick(MouseEventArgs e)
	{
		
	}
	//------------------------------------------------------------------------------------------
	
	public bool IsCurrentUnit(InteractableItemBase obj)
	{

		return currentObject == obj.gameObject;
	}
	
	public void MenuWidthChanged(float newWidth)
	{
		m_GuiWidth = newWidth;
	}
}

public enum HoverOver
{
	Menu,
	Land,
	FriendlyUnit,
	EnemyUnit,
	FriendlyBuilding,
	EnemyBuilding,
}

public enum InteractionState
{
	Nothing = 0,
	Invalid = 1,
	Move = 2,
	Attack = 3,
	Select = 4,
	Deploy = 5,
	Interact = 6,
	Sell = 7,
	CantSell = 8,
	Fix = 9,
	CantFix = 10,
	Disable = 11,
	CantDisable = 12,
}

public enum Mode
{
	Normal,
	Menu,
	PlaceBuilding,
	Disabled,
}
