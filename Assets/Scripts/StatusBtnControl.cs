using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBtnControl : MonoBehaviour
{
    public Image playerDetail;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            playerDetail.gameObject.SetActive(!playerDetail.gameObject.activeInHierarchy);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
