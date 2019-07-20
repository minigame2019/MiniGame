using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HanbitableZone
{
    
    public class MovingHanbitableZone : MonoBehaviour
    {

        GameObject cold_light_obj;
        GameObject hot_light_obj;
        float width;
        float center;

        //接受点的z坐标, -1表示在安全区内
        public void changeWidth(float new_width){
            float half_width_change = (new_width - width) / 2;
            width = new_width;
            hot_light_obj.transform.Translate(new Vector3(0,0,half_width_change));
            cold_light_obj.transform.Translate(new Vector3(0,0,half_width_change));
        }

        public float diatanceWith(float z){
            float half_width = width / 2;
            float left = center - half_width;
            float right = center + half_width;
            if(z > left && z < right){
                return -1;
            }
            return (left-z) > (z-right) ? (left-z) : (z-right);   
        }

        public void moveVertically(float distance){
            hot_light_obj.transform.Translate(new Vector3(distance,0,0));
            cold_light_obj.transform.Translate(new Vector3(-distance,0,0));
        }

        public void moveToHot(float distance){
            hot_light_obj.transform.Translate(new Vector3(0,0,distance));
            cold_light_obj.transform.Translate(new Vector3(0,0,-distance));
            center += distance;
        }

        private void init(){
            center = 0;
            width = 500;
            float half_width = width / 2;

            hot_light_obj = new GameObject("Hot Light");

            Light hot_light = hot_light_obj.AddComponent<Light>();

            hot_light.color = Color.red;
            hot_light.type = LightType.Spot;
            hot_light.range = 1000;
            hot_light.spotAngle = 179f;  

            hot_light_obj.transform.position = new Vector3(0, 250, half_width);

            cold_light_obj = new GameObject("Cold Light");

            Light cold_light = cold_light_obj.AddComponent<Light>();
            
            cold_light.color = Color.blue;
            cold_light.type = LightType.Spot;
            cold_light.range = 1000;
            cold_light.spotAngle = 179f;

            cold_light_obj.transform.position = new Vector3(0, 250, -half_width);
            Quaternion quat = new Quaternion(0, 0, 0, 1f);
            quat.eulerAngles = new Vector3(0,-180f,0);
            print(quat.eulerAngles);
            //quat.
            cold_light_obj.transform.rotation = quat;

            //to solve a strange bug
            moveVertically(100f);
            moveVertically(-100f);
        }

        // Start is called before the first frame update
        void Start()
        {
            init();
        }

        // Update is called once per frame
        void Update()
        {
            moveToHot(0.2f);
            /*
            if(Input.GetMouseButtonDown(0)){
                moveVertically(100f);
            }
            if(Input.GetMouseButtonDown(1)){
                changeWidth(width+200);
            }
            */
        }
    }

}