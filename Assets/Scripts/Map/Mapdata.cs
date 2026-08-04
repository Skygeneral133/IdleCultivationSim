using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Map
{
    [CreateAssetMenu(fileName = "MapData", menuName = "Game/MapData")]
    public class MapData : ScriptableObject
    {
        public int2 size;
        public List<SpecialTileEntry> specialTiles;
    }

    [Serializable]
    public class SpecialTileEntry
    {
        public int2 position;
        public Location location;
    }
}