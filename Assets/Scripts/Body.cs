using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Body
{
    private Dictionary<BodyStatType, Stat> stats = new Dictionary<BodyStatType, Stat>();
    
    public Body()
    {
        // initialize stats
        foreach (BodyStatType statType in System.Enum.GetValues(typeof(BodyStatType)))
        {
            stats[statType] = new Stat();
        }
    }
    
    public Stat GetStat(BodyStatType type)
    {
        return stats[type];
    }
}
