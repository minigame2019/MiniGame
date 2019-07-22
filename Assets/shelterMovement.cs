using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HabitableZoneManager;

public class shelterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void moveToX(float distance){
        this.transform.Translate(new Vector3(distance, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        moveToX(HabitableZone.speed);
    }
}
