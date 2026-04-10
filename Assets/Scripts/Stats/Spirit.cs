using System.Collections.Generic;
using System.Linq;

public class Spirit
{
    private Dictionary<SpiritStatType, Stat> stats = new Dictionary<SpiritStatType, Stat>();
    
    public Spirit()
    {
        foreach (SpiritStatType statType in System.Enum.GetValues(typeof(SpiritStatType)))
        {
            stats[statType] = new Stat();
        }
    }
    
    public Stat GetStat(SpiritStatType type)
    {
        return stats[type];
    }
    
    public SpiritStatType[] getTwoHighestSpirits()
    {
        SpiritStatType Highest = default;
        SpiritStatType secondHighest = default;
        int highestValue = 0;
        int secondHighestValue = 0;
        foreach (var kvp in stats)
        {
            if (kvp.Value.getStatValue() > highestValue)
            {
                Highest = kvp.Key;
                highestValue = kvp.Value.getStatValue();
            }

            if (kvp.Value.getStatValue() > secondHighestValue)
            {
                secondHighest = kvp.Key;
                secondHighestValue = kvp.Value.getStatValue();
            }
        }
        
        return  new SpiritStatType[] { Highest, secondHighest };
    }
}