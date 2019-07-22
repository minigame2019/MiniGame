using UnityEngine;
using System.Collections;
using System;

public interface IUIManager 
{	
	
	bool IsCurrentUnit(InteractableItemBase obj);
	
	void LeftButton_SingleClickDown(MouseEventArgs e);
	void LeftButton_DoubleClickDown(MouseEventArgs e);
	void LeftButton_SingleClickUp(MouseEventArgs e);
	
	void RightButton_SingleClick(MouseEventArgs e);
	void RightButton_DoubleClick(MouseEventArgs e);

}
