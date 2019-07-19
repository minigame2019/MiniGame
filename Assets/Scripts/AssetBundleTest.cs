using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyAssetBundleManager;


public class AssetBundleTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Mouse 0");
            GameObject x = AssetBundleManager.loadByName("cubewall.unity3d", "CubeWall");
            Instantiate(x);
            print("0 ok");
            //AssetBundle.LoadFromFile("AssetBundles/share.unity3d");
        }
        if (Input.GetMouseButtonDown(1))
        {
            print("Mouse 1");
            AssetBundleManager.unloadAssetBundle("share.unity3d");
            print("1 ok");
        }
        if (Input.GetMouseButtonDown(2))
        {
            print("Mouse 2");
            IEnumerable<AssetBundle>loaded_abs = AssetBundle.GetAllLoadedAssetBundles();
            foreach( AssetBundle x in loaded_abs){
                print(x.name);
            }
            print("2 ok");
            //AssetBundle.LoadFromFile("AssetBundles/share.unity3d");
        }
    }
}
