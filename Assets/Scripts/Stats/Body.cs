using System.Collections.Generic;

public class Body
{
    private Dictionary<BodyStatType, Stat> stats = new Dictionary<BodyStatType, Stat>();
    
    public Body()
    {
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
