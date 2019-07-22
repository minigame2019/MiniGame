using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        Transform content = this.transform.GetChild(0).GetChild(0);

        content.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 300);
        GridLayoutGroup g = content.GetComponent<GridLayoutGroup>();
        g.cellSize = new Vector2(80, 80);
        g.spacing = new Vector2(10, 10);
        Debug.Log(g.padding);
        for (int i = 0; i < 3; i++)
        {
            GameObject tem = Instantiate(Resources.Load("Slot_1")) as GameObject;
            tem.transform.parent = content;
            //tem.transform.localPosition = new Vector3(40, -40, 0) + new Vector3(80, 0, 0) * i;
            tem.transform.localScale = new Vector3(1, 1, 1);
        }*/
        /*
       Transform content = this.transform.GetChild(0).GetChild(0);
        var r = this.GetComponent<RectTransform>();
        int w =  int.Parse(r.sizeDelta.x.ToString());
        var rt = content.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(w, 80);
        for (int i = 0; i< 3; i++) {
            GameObject tem = Instantiate(Resources.Load("Slot_1")) as GameObject;
            tem.transform.parent = content;
            tem.transform.localPosition = new Vector3(40,-40,0) + new Vector3(80, 0, 0) * i;
            tem.transform.localScale = new Vector3(1, 1, 1);            
            Debug.Log(tem.transform.localPosition);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
