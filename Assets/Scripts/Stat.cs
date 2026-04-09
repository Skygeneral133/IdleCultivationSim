using TMPro;
using UnityEngine.UI;


public class Stat
{
    private int Value = 1;
    private TextMeshProUGUI textGui;
    public float upgradeCost = 1;
    private Button upgradeButton;

    public void setTextGui(TextMeshProUGUI textGui)
    {
        this.textGui = textGui;
        this.textGui.text = this.Value.ToString();
    }

    public void setUpgradeButton(Button upgradeButton)
    {
        this.upgradeButton = upgradeButton;
    }
    
    public void addValue(int  value)
    {
        this.Value += value;
        this.textGui.text = this.Value.ToString();
    }

    public Button getUpgradeButton()
    {
        return this.upgradeButton;
    }
}