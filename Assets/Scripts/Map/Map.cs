using System.Collections.Generic;
using Unity.Mathematics;

namespace Map
{
    public class Map
    {
        private Dictionary<int2, Location> _locations;
        private int2 _size;

        public Map(MapData data)
        {
            _size = data.size;
            foreach (var loc in data.specialTiles)
                if (_locations != null)
                    _locations.Add(loc.position, loc.location);
        }
    }
}