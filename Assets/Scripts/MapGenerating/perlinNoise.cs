using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perlinNoise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
   



    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

   
    Texture2D  GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for(int x = 0; x <width; x++){
            for( int y = 0 ; y < height; y++){

                Color color = CalculateColor(x,y);
                texture.SetPixel(x,y, color);

            }
        }

        texture.Apply();
        return texture;
    }

    Color CalculateColor(int x , int y)
    {
        float XCoord = (float)x/width * 20;
        float yCoord = (float)y/height * 20;

        float sample = Mathf.PerlinNoise(XCoord,yCoord);
        return new Color(sample, sample, sample);
    }

}
