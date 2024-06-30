using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class CoinCollector : MonoBehaviour
{
    public static CoinCollector instance;

    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text scoreText;
    int currentScore;
    int currentCoins;
    CoinSystem coinSystem;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        coinSystem = FindObjectOfType<CoinSystem>();
        currentCoins = coinSystem.CurrentScore;
        currentScore = coinSystem.Score;
        scoreText.text = "Score: " + currentScore.ToString();
        coinText.text = "COINS: " + currentCoins.ToString();
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        currentScore += v + 4;
        coinText.text = "COINS: " + currentCoins.ToString();
        scoreText.text = "Score: " + currentScore.ToString();
        coinSystem.SetScore(currentCoins);
        coinSystem.SetScore(currentScore);
    }

    
}
