using Enums;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private Button addButton;
    [SerializeField] private TextMeshProUGUI statText;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private StatTypes statType;
    private Stat thisButtonStat;

    public void Start()
    {
        playerStats.onStatChange += HandleStatChange;
        ChiController.OnChiChanged += CheckButtonEnabled;
        addButton.onClick.AddListener(() => playerStats.UpgradeStat(statType));
        thisButtonStat = playerStats.stats[statType];
    }

    private void HandleStatChange(StatTypes statType,  Stat stat)
    {
        if (statType != this.statType)
        {
            return;
        }
        statText.text = stat.getStatValue().ToString();
    }

    private void CheckButtonEnabled(float currentChi)
    {
        if (currentChi >= thisButtonStat.upgradeCost)
        {
            addButton.interactable = true;
        }
        else
        {
            addButton.interactable = false;
        }
    }
}
