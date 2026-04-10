using TMPro;
using UnityEngine.UI;


public class Stat
{
    private int Value = 1;
    public float upgradeCost = 1;
    
    public void addValue(int  value)
    {
        this.Value += value;
    }

    public int getStatValue()
    {
        return Value;
    }
    
}