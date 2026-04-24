using System;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private Tile[,] grid;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform parentTransform;

    private void Start()
    {
        generateGrid(3, 5);
    }

    void generateGrid(int width, int height)
    {
        grid = new Tile[width, height];
        
        RectTransform parentRect = parentTransform.GetComponent<RectTransform>();
        float parentWidth = parentRect.rect.width;
        float parentHeight = parentRect.rect.height;
        
        float tileWidth = parentWidth / width;
        float tileHeight = parentHeight / height;
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var spawnedTile = Instantiate(tilePrefab, parentTransform);
                RectTransform rt = spawnedTile.GetComponent<RectTransform>();

                // Set size of each tile
                rt.sizeDelta = new Vector2(tileWidth, tileHeight);
                
                // Anchor to top-left corner
                rt.anchorMin = new Vector2(0, 1);
                rt.anchorMax = new Vector2(0, 1);
                rt.pivot = new Vector2(0, 1);
                
                // Position from top-left (j inverted for Unity's bottom-up Y axis)
                rt.anchoredPosition = new Vector2(
                    i * tileWidth,
                    -j * tileHeight  // Negative because Unity UI Y goes up, but we want down
                );
                
                rt.localScale = Vector3.one;
                
                spawnedTile.gridPosition = new Vector2Int(i, j);
                grid[i, j] = spawnedTile;
            }
        }
    }
}