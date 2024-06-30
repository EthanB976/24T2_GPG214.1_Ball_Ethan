using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    CoinSystem coinSystem;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
           
        }
    }
}
