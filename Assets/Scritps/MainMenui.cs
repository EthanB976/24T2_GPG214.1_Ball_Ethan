using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenui : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<CoinSystem>().SetScore(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
