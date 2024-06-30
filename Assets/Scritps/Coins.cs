using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int value;

    public string fileName = "Coin3.wav";
    public string folderName = "Sounds";
    private string combinedFilePath;

    public AudioSource audioSource;
    private AudioClip coinClip;

    private void Start()
    {
        combinedFilePath = Path.Combine(Application.streamingAssetsPath, folderName, fileName);
        audioSource = GetComponentInParent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("Error no audio souce componet attached");
            return;
        }

        LoadSoundFromFile();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinCollector.instance.IncreaseCoins(value);
            PlaySound();
            Destroy(gameObject);
        }
    }

    private void LoadSoundFromFile()
    {
        if (File.Exists(combinedFilePath))
        {
            byte[] audioData = File.ReadAllBytes(combinedFilePath);

            // Convert bytes to float array
            float[] floatArray = new float[audioData.Length / 2];
            for (int i = 0; i < floatArray.Length; i++)
            {
                // Convert 16-bit PCM to float
                short bitValue = BitConverter.ToInt16(audioData, i * 2);
                floatArray[i] = bitValue / 32768.0f; // Normalize to [-1, 1]
            }

            // Create AudioClip
            coinClip = AudioClip.Create("coinClip", floatArray.Length, 1, 44100, false);
            coinClip.SetData(floatArray, 0);
        }
        else
        {
            Debug.LogError("No file found at path: " + combinedFilePath);
        }
    }


    private void PlaySound()
    {
        if (audioSource == null || coinClip == null)
        {
            return;
        }
        audioSource.PlayOneShot(coinClip);
    }
}
