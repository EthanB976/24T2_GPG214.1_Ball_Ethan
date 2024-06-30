using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;


public class FileSystems : MonoBehaviour
{

    private void Start()
    {
        string assetPath = Application.dataPath;
        if (Directory.Exists(assetPath))
        {
            Debug.Log("Asset Path" + assetPath);
        }

        string persistantpath = Application.persistentDataPath;
        if (Directory.Exists(persistantpath))
        {
            Debug.Log("Persistant Data Path" + persistantpath);
        }

        string streamingAssetsPath = Application.streamingAssetsPath;
        if (Directory.Exists(streamingAssetsPath))
        {
            Debug.Log("StreamingAssetsPath" + streamingAssetsPath);
        }
        else
        {
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "StreamingAssets"));
            Debug.Log("StreamingAssetsPath" + streamingAssetsPath);
        }

        if (File.Exists(Path.Combine(Application.streamingAssetsPath, "PlayerInfo.txt")))
        {
            Debug.Log("Yay text file exists.");
        }
        else
        {
            File.CreateText(Path.Combine(Application.streamingAssetsPath, "PlayerInfo.txt"));
        }

        

    }

    
    
}
