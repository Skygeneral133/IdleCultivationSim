using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChiController : MonoBehaviour
{
    [SerializeField]
    private float chiCount;
    public PlayerStats playerStats;
    public TextMeshProUGUI chiCountText;
    public float chiProgressRate;
    public ProgressBar chiProgress;
    public int chiIncreaseRate;
    
    // Start is called before the first frame update
    void Start()
    {
        chiCountText.text = chiCount.ToString();
        InvokeRepeating("UpdateChiCountProgress", 0f, 1.0f);
    }

    public float getChiCount()
    {
        return chiCount;
    }
    
    public void addChiCount(float value)
    {
        chiCount += value;
        chiCountText.text = chiCount.ToString();
    }

    public void minusChiCount(float value)
    {
        chiCount -= value;
        chiCountText.text = chiCount.ToString();
    }

    void UpdateChiCountProgress()
    {
        chiProgress.current += chiProgressRate;
        chiProgress.GetCurrentFill();
        CheckIfChiComplete();
    }

    void CheckIfChiComplete()
    {
        if (chiProgress.current >= chiProgress.maximum)
        {
            chiCount += chiIncreaseRate;
            chiProgress.current = 0;
            chiProgress.GetCurrentFill();
            chiCountText.text = chiCount.ToString();
            playerStats.CheckButtonsInteractable();
        }
    }
}
