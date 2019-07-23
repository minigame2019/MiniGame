using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface ISelectedManager {

	void AddObject(PlayerController obj);
	void DeselectObject(PlayerController obj);
	void DeselectAll();
	void AddUnitsToGroup(int number);
	void SelectGroup(int number);
	//void GiveOrder(Order order);
	
	int ActiveObjectsCount();
	
	bool IsObjectSelected(GameObject obj);
	
	PlayerController FirstActiveObject();
	List<PlayerController>ActiveObjectList();
}
