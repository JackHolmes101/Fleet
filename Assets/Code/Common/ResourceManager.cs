using UnityEngine;
using System.Collections;
using System.IO;
using System;

namespace RTS
{
    public static class ResourceManager
    {
        private static AssetBundle loadedAssetBundle = null;

        public static AssetBundle LoadedAssetBundle
        {
            get { return loadedAssetBundle; }
        }

        public static void loadAssets() 
        {
            //string path = Path.Combine(Application.streamingAssetsPath, @"AssetBundles\ShipBuilding");
            string path = @"C:\Users\Jack\Documents\Fleet\Assets\AssetBundles\ShipBuilding";

            loadedAssetBundle = AssetBundle.LoadFromFile(path);
            if (loadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                return;
            }
            //var prefab = myLoadedAssetBundle.LoadAsset("Placement");
            //Instantiate(prefab);
        }


    }
}
