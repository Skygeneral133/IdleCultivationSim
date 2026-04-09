using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public int maxHp = 10;
    public int maxMana = 10;
    public double baseAttack = 1;
    public double baseDefense = 1;
    public double baseSpeed = 1;
    private Body Body = new Body();
    public TextMeshProUGUI[] statBodyTexts;
    public Button[] bodyStatButtons;
    public Spirit Spirit;
    public ChiController ChiController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int i = 0;
        foreach (BodyStatType type in System.Enum.GetValues(typeof(BodyStatType)))
        {
            Body.GetStat(type).setTextGui(statBodyTexts[i]);
            Body.GetStat(type).setUpgradeButton(bodyStatButtons[i]);
            BodyStatType capturedType = type;
            bodyStatButtons[i].onClick.AddListener(() => UpgradeBodyStat(capturedType));
            i++;
        }
    }

    public void CheckButtonsInteractable()
    {
        foreach (BodyStatType type in System.Enum.GetValues(typeof(BodyStatType)))
        {
            Body.GetStat(type).getUpgradeButton().interactable = !(Body.GetStat(type).upgradeCost > ChiController.getChiCount());
        }
    }

    private void UpgradeBodyStat(BodyStatType type)
    {
        ChiController.minusChiCount(Body.GetStat(type).upgradeCost);
        Body.GetStat(type).addValue(1);
        
        switch(type)
        {
            case BodyStatType.TENDONS:
                baseDefense += 1;
                baseAttack += 0.5;
                break;
            case BodyStatType.ORGAN:
                maxHp += 10;
                maxMana += 10;
                break;
            case BodyStatType.MUSCLES:
                baseAttack += 1;
                baseSpeed += 0.5;
                break;
            case BodyStatType.REACTION:
                baseDefense += 1;
                baseSpeed += 0.5;
                break;
            case BodyStatType.SKELETON:
                baseDefense += 1;
                baseAttack += 0.5;
                break;
        }
    }

}
