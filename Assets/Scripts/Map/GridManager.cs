using System.Collections;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tile tilePrefab;
    public Map.Map CurrentMap;
    private Tile[,] grid;

    private void Start()
    {
        StartCoroutine(GenerateGridAfterLayout(3, 5));
    }

    private IEnumerator GenerateGridAfterLayout(int width, int height)
    {
        // Wait for end of frame to ensure layout has been calculated
        yield return new WaitForEndOfFrame();

        GenerateGrid(width, height);
    }


    private void GenerateGrid(int width, int height)
    {
        grid = new Tile[width, height];

        var selfRect = GetComponent<RectTransform>();

        var Width = selfRect.rect.width;
        var Height = selfRect.rect.height;

        var tileWidth = Width / width;
        var tileHeight = Height / height;

        for (var i = 0; i < width; i++)
        for (var j = 0; j < height; j++)
        {
            var spawnedTile = Instantiate(tilePrefab, selfRect.transform);
            var rt = spawnedTile.GetComponent<RectTransform>();

            // Set size of each tile
            rt.sizeDelta = new Vector2(tileWidth, tileHeight);

            // Anchor to top-left corner
            rt.anchorMin = new Vector2(0, 1);
            rt.anchorMax = new Vector2(0, 1);
            rt.pivot = new Vector2(0, 1);

            // Position from top-left (j inverted for Unity's bottom-up Y axis)
            rt.anchoredPosition = new Vector2(
                i * tileWidth,
                -j * tileHeight // Negative because Unity UI Y goes up, but we want down
            );

            rt.localScale = Vector3.one;

            spawnedTile.gridPosition = new Vector2Int(i, j);
            grid[i, j] = spawnedTile;
        }
    }
}