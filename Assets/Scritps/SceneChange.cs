using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    int savedScene;
    int sceneIndex;

    public void NewGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadSavedScene()
    {
        savedScene = PlayerPrefs.GetInt("Saved");

        if (savedScene != 0)
        {
            SceneManager.LoadSceneAsync(savedScene);
        }
        else
        {
            return;
        }
    }

    public void SaveandExit()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Saved", sceneIndex);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync(0);
    }
}
