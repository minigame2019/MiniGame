using UnityEngine;
using System.Collections;
using System;

public partial class EventsManager {
	
	//-----------------------Double Click Paramters------------------
	public float doubleClickTime = 300.0f;	
	private bool checkForDoubleClick = false;	
	private DateTime timeAtFirstClick;

	private void CheckMouseClicks()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (MouseClick != null) 
			{
                MouseClick(this, new LeftButton_Handler((int)Input.mousePosition.x, (int)Input.mousePosition.y, 0));
			}
		}	
		
		if (Input.GetMouseButtonUp (0))
		{
			if (MouseClick != null) 
			{
				MouseClick(this, new LeftButton_Handler((int)Input.mousePosition.x, (int)Input.mousePosition.y, 0)
				{
					buttonUp = true,
				});
			}
		}
		
		if (Input.GetMouseButtonDown (1))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			//if (Physics.Raycast (ray, out hit, Mathf.Infinity, 1 << 8 | 1 << 9 | 1 << 12 | 1 << 13))
           // {
				//Right Clicked on unit or building
				//if (MouseClick != null) 
				//{
					//MouseClick(this, new RightButton_Handler((int)Input.mousePosition.x, (int)Input.mousePosition.y, 1, hit.collider.gameObject.GetComponent<InteractableItemBase>()));
				//}
		//	}
			if (Physics.Raycast (ray, out hit, Mathf.Infinity, 1))
			{
				//Right clicked on terrain
				if (MouseClick != null) 
				{
                    MouseClick(this, new RightButton_Handler((int)Input.mousePosition.x, (int)Input.mousePosition.y, 1, hit.point));
                }
            }
        }
		
		
		if (checkForDoubleClick)
		{
			if ((DateTime.Now-timeAtFirstClick).Milliseconds >= doubleClickTime)
			{
				checkForDoubleClick = false;
			}
		}
	}
	
	private void DoubleClickCheck(object sender, MouseEventArgs e)
	{
		if (e.doubleClick || e.buttonUp) return;
		
		if (checkForDoubleClick)
		{
			TimeSpan timeBetweenClicks = DateTime.Now-timeAtFirstClick;
			
			if (timeBetweenClicks.Milliseconds < doubleClickTime)
			{
				e.doubleClick = true;				
			}
		}
		else
		{
			checkForDoubleClick = true;
			timeAtFirstClick = DateTime.Now;
		}		
	}
}
