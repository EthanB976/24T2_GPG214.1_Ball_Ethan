using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssetBudles : MonoBehaviour
{
    string folderPath = "AssetBundles";
    string fileName = "bundle1";
    string combinedPath;
    private AssetBundle bundle1Bundle;

    // Start is called before the first frame update
    void Start()
    {
        LoadAssetBundle();
        LoadPlayer();
    }

    

    void LoadPlayer()
    {
        if (bundle1Bundle == null)
        {
            return;
        }

        GameObject playerPrefab = bundle1Bundle.LoadAsset<GameObject>("player");

        if (playerPrefab != null )
        {
            Instantiate(playerPrefab);
        }
    }
    void LoadAssetBundle()
    {
        combinedPath = Path.Combine(Application.streamingAssetsPath, folderPath, fileName);

        if (File.Exists(combinedPath))
        {
            bundle1Bundle = AssetBundle.LoadFromFile(combinedPath);
            Debug.Log("Asset Bundle Loaded");
        }
        else
        {
            Debug.Log("File does not exist " +  combinedPath);
        }
    }
}
