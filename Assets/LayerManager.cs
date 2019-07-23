using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HabitableZoneManager;

public class LayerManager : MonoBehaviour
{
    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    public void layerCheck(){
        float left = HabitableZone.left_bound;
        float right = HabitableZone.right_bound;
        print("left");
        print(left);

        float x = this.transform.position.x;
        if(x < left){
            changeLayer(this.transform, LayerMask.NameToLayer("cold"));
        }

        if(x > right){
            changeLayer(this.transform, LayerMask.NameToLayer("hot"));
        }

    }
/*
    public void layerCheckRecursion(Transform root, float left_bound, bool if_change_to_cold = true){
        float x = this.transform.posit
        
    }
*/
    public void changeLayer(Transform trans, int target){
        trans.gameObject.layer = target;
    }

    // Update is called once per frame
    void Update()
    {
        if(count < 100)
        {
            count++;
        }
        else
        {
            count = 0;
            //layerCheck();
        }
    }
}
