using UnityEngine;
using System.Collections;

public class Selected : MonoBehaviour
{

     public bool IsSelected
     {
          get;
          private set;
     }

     private bool m_JustBeenSelected = false;
     private float m_JustBeenSelectedTimer = 0;
     private Material m_GLMat;

     private Texture2D Overlay;
     private Rect OverlayRect = new Rect();

     private float m_OverlayWidth = 20;
     private float m_OverlayLength = 30;


     // Use this for initialization
     void Start()
     {
          IsSelected = false;
     }

     // Update is called once per frame
     void Update()
     {
          //Update overlay rect
          Vector3 centerPoint = Camera.main.WorldToScreenPoint(transform.position);
          OverlayRect.xMin = centerPoint.x - (m_OverlayWidth / 2.0f);
          OverlayRect.xMax = centerPoint.x + (m_OverlayWidth / 2.0f);
          OverlayRect.yMax = Screen.height - (centerPoint.y - (m_OverlayLength / 2.0f) - 5);
          OverlayRect.yMin = Screen.height - (centerPoint.y + (m_OverlayLength / 2.0f) + 15);

          if (m_JustBeenSelected)
          {
               m_JustBeenSelectedTimer += Time.deltaTime;

               if (m_JustBeenSelectedTimer >= 1.0f)
               {
                    m_JustBeenSelectedTimer = 0;
                    m_JustBeenSelected = false;
               }
          }
     }

     void OnGUI()
     {
          if (IsSelected)
          {
               GUI.DrawTexture(OverlayRect, Overlay);
          }
     }

     public void SetSelected()
     {
          IsSelected = true;
          m_JustBeenSelected = true;
          m_JustBeenSelectedTimer = 0;
     }

     public void SetDeselected()
     {
          IsSelected = false;
          m_JustBeenSelected = false;
     }
}
