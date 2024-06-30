using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TextureLoader : MonoBehaviour
{
    public string fileName = "Sprites/Knight2.png";
    public string folderPath = Application.streamingAssetsPath;
    private string combinedFilePathLocation;

    public Sprite knight;
    public GameObject spriteRend;

    private void Start()
    {
        // combine the path
        combinedFilePathLocation = Path.Combine(folderPath, fileName);

        LoadSprite();
    }

    private void LoadSprite()
    {
        if (File.Exists(combinedFilePathLocation))
        {
            SpriteRenderer spriteRenderer = spriteRend.GetComponent<SpriteRenderer>();

            // read in all the bytes of data i.e 1001010
            byte[] spriteBytes = File.ReadAllBytes(combinedFilePathLocation);

            Texture2D texture = new Texture2D(2, 2);
            // takes bytes in and converts it into an image
            texture.LoadImage(spriteBytes);

            knight = Sprite.Create(texture, new Rect(10, 20, texture.width - 10, texture.height - 20), new Vector2(0.5f, 0.5f));

           

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = knight;
                
            }
            else
            {
                Debug.Log("SpriteRenderer component not found on target GameObject");
            }
        }
        else
        {
            Debug.Log("Texture File not Found at Path" + combinedFilePathLocation);
        }
    }
}
