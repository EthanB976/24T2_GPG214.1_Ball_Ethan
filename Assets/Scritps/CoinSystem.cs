using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    string coinKey = "Score";

    string scoreKey = "Total";

    public int CurrentScore {  get; set; }

    public int Score { get; set; }

    private void Awake()
    {
        CurrentScore = PlayerPrefs.GetInt(coinKey);

        Score = PlayerPrefs.GetInt(scoreKey);
    }

    public void SetScore(int score)
    {
        PlayerPrefs.SetInt(coinKey, score);

        PlayerPrefs.SetInt(scoreKey, score);
    }
}
