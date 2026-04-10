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
    
    public Body Body = new Body();
    public Spirit Spirit = new Spirit();

    public ChiController chiController;


    public bool CanUpgradeBodyStat(BodyStatType type)
    {
        Stat currentStat = Body.GetStat(type);
        return currentStat.upgradeCost < chiController.getChiCount();
    }
    
    public bool CanUpgradeSpiritStat(SpiritStatType type)
    {
        Stat currentStat = Spirit.GetStat(type);
        return currentStat.upgradeCost < chiController.getChiCount();
    }

    public void TryUpgradeBodyStat(BodyStatType type)
    {
        Stat currentStat = Body.GetStat(type);
        if (currentStat.upgradeCost < chiController.getChiCount())
        {
            UpgradeBodyStat(type);
        }
    }

    public void TryUpgradeSpiritStat(SpiritStatType type)
    {
        Stat currentStat = Spirit.GetStat(type);
        if (currentStat.upgradeCost < chiController.getChiCount())
        {
            currentStat.addValue(1);
            chiController.minusChiCount(currentStat.upgradeCost);
        }
    }
    

    private void UpgradeBodyStat(BodyStatType type)
    {
        chiController.minusChiCount(Body.GetStat(type).upgradeCost);
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
