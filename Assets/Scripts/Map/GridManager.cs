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


    // ai generated 
    private void GenerateGrid(int gridWidth, int gridHeight)
    {
        // initialize grid
        grid = new Tile[gridWidth, gridHeight];

        //GET REFERENCE TO THE ABOVE
        var selfRect = GetComponent<RectTransform>();
        // get the width and height of the parent rect
        var width = selfRect.rect.width;
        var height = selfRect.rect.height;
        
        // get the width and height of individual grid
        var tileWidth = width / gridWidth;
        var tileHeight = height / gridHeight;

        // what I don't understand right is look at this syntax the first loop has no brackets no? but it works C#
        for (var i = 0; i < gridWidth; i++)
        for (var j = 0; j < gridHeight; j++)
        {
            // ok so you spawn the tile idk what selfRect.transform is tho
            var spawnedTile = Instantiate(tilePrefab, selfRect.transform);
            // then you get the actual rect transform out fromt he tile?
            var rt = spawnedTile.GetComponent<RectTransform>();

            // Set size of each tile
            rt.sizeDelta = new Vector2(tileWidth, tileHeight);

            // Anchor to top-left corner
            // now this one is strange idk what this does
            rt.anchorMin = new Vector2(0, 1);
            rt.anchorMax = new Vector2(0, 1);
            rt.pivot = new Vector2(0, 1);

            // Position from top-left (j inverted for Unity's bottom-up Y axis)
            // oh yeah because of this
            rt.anchoredPosition = new Vector2(
                i * tileWidth,
                -j * tileHeight // Negative because Unity UI Y goes up, but we want down
            );

            // wtf is localscale tho and what is vector 3.one
            rt.localScale = Vector3.one;

            //ok so this just puts the spawntile position in its internal pointer
            spawnedTile.gridPosition = new Vector2Int(i, j);
            // this puts it in our grid
            grid[i, j] = spawnedTile;
        }
    }
}
