﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace EverTwiilight
{
    public class ObjectPlacer : MonoBehaviour
    {
        // GameObject to place.
        // When using a Grid Graph you need to make sure the object's layer is included in the collision mask in the GridGraph settings.
        public GameObject go;

        // Flush Graph Updates directly after placing. Slower, but updates are applied immidiately
        public bool direct = false;

        // Issue a graph update object after placement
        public bool issueGUOs = true;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("p"))
            {
                PlaceObject();
            }

            if (Input.GetKeyDown("r"))
            {
                StartCoroutine(RemoveObject());
            }
        }

        public void PlaceObject()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Figure out where the ground is
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 p = hit.point;
                GameObject obj = GameObject.Instantiate(go, p, Quaternion.identity) as GameObject;

                if (issueGUOs)
                {
                    Bounds b = obj.GetComponent<Collider>().bounds;
                    GraphUpdateObject guo = new GraphUpdateObject(b);
                    AstarPath.active.UpdateGraphs(guo);
                    if (direct)
                    {
                        AstarPath.active.FlushGraphUpdates();
                    }
                }
            }
        }

        public IEnumerator RemoveObject()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check what object is under the mouse cursor
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // Ignore ground and triggers
                if (hit.collider.isTrigger || hit.transform.gameObject.name == "Ground") yield break;

                Bounds b = hit.collider.bounds;
                Destroy(hit.collider);
                Destroy(hit.collider.gameObject);

                if (issueGUOs)
                {
                    // In Unity, object destruction is actually delayed until the end of the Update loop.
                    // This means that we need to wait until the end of the frame (or until the next frame) before
                    // we update the graph. Otherwise the graph would still think that the objects are there.
                    yield return new WaitForEndOfFrame();
                    GraphUpdateObject guo = new GraphUpdateObject(b);
                    AstarPath.active.UpdateGraphs(guo);
                    if (direct)
                    {
                        AstarPath.active.FlushGraphUpdates();
                    }
                }
            }
        }
    }
}
