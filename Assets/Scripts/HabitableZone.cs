using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HabitableZoneManager
{
    
public class HabitableZone : MonoBehaviour
{
    static public float left_bound;
    static public float right_bound;
    static public float speed;
    // Start is called before the first frame update
    void Start()
    {
        left_bound = -100f;
        right_bound = 100f;
        speed = 0.1f;
    }
    
    // 0 : 内
    // + ：热带及距离
    // - : 冷带及距离
    public float distanceWith(float x){
        if(x >= left_bound && x <= right_bound){
            return 0;
        }
        if(x < left_bound){
            return x - left_bound;
        }
        return x - right_bound;
    }

    // Update is called once per frame
    void Update()
    {
        left_bound += speed;
        right_bound += speed;
    }
}

}