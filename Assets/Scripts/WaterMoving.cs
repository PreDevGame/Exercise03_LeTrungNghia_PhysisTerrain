using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMoving : MonoBehaviour
{
    public int depth = 3;

    public int width = 1200;
    public int height = 500;

    public float scale = 10.0f;
    public float offSetX = 100.0f;
    public float offSetY = 100.0f;

    public float speedWater = 5.0f;

    void Start()
    {
        offSetX = Random.Range(0f, 99999f);
        offSetY = Random.Range(0f, 99999f);
    }
    void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
        offSetY += Time.deltaTime * speedWater;
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeight());

        return terrainData;
    }

    float[,] GenerateHeight()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offSetX;
        float yCoord = (float)y / height * scale + offSetY;

        return Mathf.PerlinNoise(xCoord, yCoord);

    }

}
