using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public double maxHp = 10;
    public double currentHp;
    public double maxMana = 10;
    public double currentMana;

    public double attack = 1;
    public double defense = 1;
    public double speed = 1;

    public double[] battleStats = new double[4];

    public ChiController chiController;
    public Action<StatTypes, Stat> OnStatChange;

    public Dictionary<StatTypes, Stat> Stats = new();

    public void Awake()
    {
        foreach (StatTypes statType in Enum.GetValues(typeof(StatTypes))) Stats.Add(statType, new Stat());
    }

    public void UpgradeStat(StatTypes type)
    {
        chiController.MinusChiCount(Stats[type].UpgradeCost);
        Stats[type].AddValue(1);
        OnStatChange.Invoke(type, Stats[type]);

        switch (type)
        {
            case StatTypes.Tendons:
                defense += 1;
                attack += 0.5;
                break;
            case StatTypes.Organ:
                maxHp += 10;
                maxMana += 10;
                break;
            case StatTypes.Muscles:
                attack += 1;
                speed += 0.5;
                break;
            case StatTypes.Reaction:
                defense += 1;
                speed += 0.5;
                break;
            case StatTypes.Skeleton:
                defense += 1;
                attack += 0.5;
                break;
        }
    }
}