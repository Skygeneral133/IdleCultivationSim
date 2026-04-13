using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;



public class PlayerStats : MonoBehaviour
{
    public int maxHp = 10;
    public int maxMana = 10;
    
    public double baseAttack = 1;
    public double baseDefense = 1;
    public double baseSpeed = 1;
    
    public Dictionary<StatTypes, Stat> stats = new Dictionary<StatTypes, Stat>();
    public Action<StatTypes, Stat> onStatChange;

    public ChiController chiController;

    public void Awake()
    {
        foreach (StatTypes statType in Enum.GetValues(typeof(StatTypes)))
        {
            stats.Add(statType, new Stat());
        }
    }

    public void UpgradeStat(StatTypes type)
    {
        chiController.minusChiCount(stats[type].upgradeCost);
        stats[type].addValue(1);
        onStatChange.Invoke(type, stats[type]);
        
        switch(type)
        {
            case StatTypes.TENDONS:
                baseDefense += 1;
                baseAttack += 0.5;
                break;
            case StatTypes.ORGAN:
                maxHp += 10;
                maxMana += 10;
                break;
            case StatTypes.MUSCLES:
                baseAttack += 1;
                baseSpeed += 0.5;
                break;
            case StatTypes.REACTION:
                baseDefense += 1;
                baseSpeed += 0.5;
                break;
            case StatTypes.SKELETON:
                baseDefense += 1;
                baseAttack += 0.5;
                break;
        }
        
    }

}
