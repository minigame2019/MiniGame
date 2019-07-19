using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

namespace MyAssetBundleManager
{

    public class AssetBundleManager : MonoBehaviour {

        static AssetBundle manifestAB;
        static AssetBundleManifest manifest;
        private void init(){
            manifestAB = AssetBundle.LoadFromFile("AssetBundles/AssetBundles");
            manifest = manifestAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        }

        public void Start(){
            print("AssetBundelMannager start");
            init();
        }

        public static void loadDependencies(string asset_bundle_name){
            //fresh();
            string[] strs =  manifest.GetAllDependencies(asset_bundle_name);
            print(asset_bundle_name + "  Depends on : ");
            foreach (string name in strs)
            {
                print(name);
                loadAssetBundle(name);
            }
        }

        public static AssetBundle loadAssetBundle(string asset_bundle_name){
            IEnumerable<AssetBundle>loaded_abs = AssetBundle.GetAllLoadedAssetBundles();
            foreach(AssetBundle x in loaded_abs){
                if(x.name == asset_bundle_name){
                    loadDependencies(asset_bundle_name);
                    return x;
                }
            }
            AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync("AssetBundles/" + asset_bundle_name);
            print("load : " + asset_bundle_name);
            loadDependencies(asset_bundle_name);
            return request.assetBundle;
        }

        public static GameObject loadByName(string asset_bundle_name, string asset_name){
            AssetBundle ab = loadAssetBundle(asset_bundle_name);
            GameObject obj = ab.LoadAsset<GameObject>(asset_name);
            return obj;
        }

        public static void unloadAssetBundle(string asset_bundle_name, bool unload_all_dependencies = false){
            print("unload: " + asset_bundle_name);
            print(unload_all_dependencies);
            IEnumerable<AssetBundle>loaded_abs = AssetBundle.GetAllLoadedAssetBundles();
            foreach(AssetBundle x in loaded_abs){
                if(x.name == asset_bundle_name){
                    x.Unload(unload_all_dependencies);
                    print("unload succees");
                    break;
                }
            }
        }

    }

}