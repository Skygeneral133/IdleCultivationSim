using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
        public PlayerStats playerStats;
        public Button[] bodyStatButtons;
        public TextMeshProUGUI[] statBodyTexts;
        public Button[] spiritStatButtons;
        public TextMeshProUGUI[] statSpritTexts;
        
        void Start()
        {
                int i = 0;

                foreach (BodyStatType type in System.Enum.GetValues(typeof(BodyStatType)))
                {
                        BodyStatType capturedType = type;
                        bodyStatButtons[i].onClick.AddListener(() => OnBodyUpgradeClicked(capturedType));
                        statBodyTexts[i].text = playerStats.Body.GetStat(capturedType).getStatValue().ToString();
                        i++;
                }
                
                int j = 0;
                
                foreach (SpiritStatType type in System.Enum.GetValues(typeof(SpiritStatType)))
                {
                        SpiritStatType capturedType = type;
                        spiritStatButtons[j].onClick.AddListener(() => OnSpiritUpgradeClicked(capturedType));
                        statSpritTexts[j].text = playerStats.Spirit.GetStat(capturedType).getStatValue().ToString();
                        j++;
                }
                
                ChiController.OnChiChanged += HandleChiChanged;
                CheckButtonsInteractable();
                RefreshUI();
        }

        private void OnBodyUpgradeClicked(BodyStatType type)
        {
                playerStats.TryUpgradeBodyStat(type);
        }
        
        private void OnSpiritUpgradeClicked(SpiritStatType type)
        {
                playerStats.TryUpgradeSpiritStat(type);
        }
        
        public void RefreshUI()
        {
                
                int i = 0;
                foreach (BodyStatType type in System.Enum.GetValues(typeof(BodyStatType)))
                { 
                        BodyStatType capturedType = type;
                        statBodyTexts[i].text = playerStats.Body.GetStat(capturedType).getStatValue().ToString();
                        i++;
                }

                int j = 0;
                
                foreach (SpiritStatType type in System.Enum.GetValues(typeof(SpiritStatType)))
                {
                        SpiritStatType capturedType = type;
                        statSpritTexts[j].text = playerStats.Spirit.GetStat(capturedType).getStatValue().ToString();
                        j++;
                }
        }
        
        private void CheckButtonsInteractable()
        {
                int i = 0;
                foreach (BodyStatType type in System.Enum.GetValues(typeof(BodyStatType)))
                {
                        if (!playerStats.CanUpgradeBodyStat(type))
                        {
                                bodyStatButtons[i].interactable = false;
                        }
                        else
                        {
                                bodyStatButtons[i].interactable = true;
                        }
                        i++;
                }
                int j = 0;
                foreach (SpiritStatType type in System.Enum.GetValues(typeof(SpiritStatType)))
                {
                        if (!playerStats.CanUpgradeSpiritStat(type))
                        {
                                spiritStatButtons[j].interactable = false;
                        }
                        else
                        {
                                spiritStatButtons[j].interactable = true;
                        }
                        j++;
                }
        }
        
        private void HandleChiChanged(float chi)
        {
                CheckButtonsInteractable();
                RefreshUI();
        }
}
