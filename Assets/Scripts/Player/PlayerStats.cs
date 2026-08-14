using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHp = 10;
    public float currentHp;
    public float maxMana = 10;
    public float currentMana;

    public float attack = 1;
    public float defense = 1;
    public float speed = 1;

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
                defense += 1f;
                attack += 0.5f;
                break;
            case StatTypes.Organ:
                maxHp += 10f;
                maxMana += 10f;
                break;
            case StatTypes.Muscles:
                attack += 1f;
                speed += 0.5f;
                break;
            case StatTypes.Reaction:
                defense += 1f;
                speed += 0.5f;
                break;
            case StatTypes.Skeleton:
                defense += 1f;
                attack += 0.5f;
                break;
        }
    }
}