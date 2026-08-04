using Enums;
using TMPro;
using UnityEngine;
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
        playerStats.OnStatChange += HandleStatChange;
        ChiController.OnChiChanged += CheckButtonEnabled;
        addButton.onClick.AddListener(() => playerStats.UpgradeStat(statType));
        thisButtonStat = playerStats.Stats[statType];
    }

    private void HandleStatChange(StatTypes statType, Stat stat)
    {
        if (statType != this.statType) return;
        statText.text = stat.GetStatValue().ToString();
    }

    private void CheckButtonEnabled(float currentChi)
    {
        if (currentChi >= thisButtonStat.UpgradeCost)
            addButton.interactable = true;
        else
            addButton.interactable = false;
    }
}