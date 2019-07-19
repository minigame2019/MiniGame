using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestScript : MonoBehaviour
{  
    public GameObject btnObj;
    Button btn;
    bool isshow = false;
    // Use this for initialization
    private void Awake()
    {
    }

    void Start()
    {
        Button b = this.transform.GetComponent<Button>();
        Debug.Log(b);
        Debug.Log(b.name);
        Button c = b.transform.GetComponent<Button>();
        Debug.Log(c); Debug.Log(c.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
