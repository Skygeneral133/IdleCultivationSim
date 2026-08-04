public class Stat
{
    public float UpgradeCost = 1;
    private int _value = 1;

    public void AddValue(int value)
    {
        _value += value;
    }

    public int GetStatValue()
    {
        return _value;
    }
}