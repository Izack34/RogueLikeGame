using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    public static float[,] GenerateNoiseMap(int MapWidth, int MapHeight, 
                                        float scale, int octaves , float persistance, float lacunarity){
        
        if( scale <= 0){
            scale = 0.0001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        float[,] noiseMap = new float[MapWidth, MapHeight];

        for (int y = 0; y < MapHeight; y++){
                for( int x = 0 ; x < MapWidth; x++){

                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for( int i = 0 ; i < octaves; i++){
                    float sampleX = x/ scale * frequency;
                    float sampleY = y/ scale * frequency;

                    float PerlinValue = Mathf.PerlinNoise(sampleX , sampleY) *2-1;

                    noiseHeight += PerlinValue* amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;

                }

                if(noiseHeight > maxNoiseHeight){
                    maxNoiseHeight = noiseHeight;
                }else if(noiseHeight < minNoiseHeight){
                    minNoiseHeight = noiseHeight;
                }
                noiseMap[x,y] = noiseHeight;
            }
        }

        for (int y = 0; y < MapHeight; y++){
            for( int x = 0 ; x < MapWidth; x++){
                noiseMap[x,y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x,y]);
            }
        }


        return noiseMap;
    }    
}
