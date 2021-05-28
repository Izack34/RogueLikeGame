using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapgenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;
    public float persistance;
    public float lacunarity;
    public TerrainType[] regions;
    private void Update() {
        GenerateMap();
    }
    
    public void GenerateMap(){
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth,mapHeight, noiseScale,octaves, persistance,lacunarity);


        Color[] colourMap = new Color[mapWidth*mapHeight];

        for (int y = 0; y < mapHeight; y++){
                for( int x = 0 ; x < mapWidth; x++){
                    float currentHeight = noiseMap[x,y];
                    for(int i = 0; i < regions.Length; i++){
                        if(currentHeight <= regions[i].height){ 
                            colourMap[y * mapWidth +x] = regions[i].colour;
                            break;
                        }
                    }            
                }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapWidth, mapHeight));
    }

}
[System.Serializable]
public struct TerrainType{
    public string name;
    public float height;
    public Color colour;
}