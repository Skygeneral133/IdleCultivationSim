using System;
using UnityEngine;
using TMPro;

public class ChiController : MonoBehaviour
{
    [SerializeField]
    private float chiCount;

    public static event Action<float> OnChiChanged;
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
        OnChiChanged?.Invoke(value);
    }

    public void minusChiCount(float value)
    {
        chiCount -= value;
        chiCountText.text = chiCount.ToString();
        OnChiChanged?.Invoke(value);
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
            addChiCount(chiIncreaseRate);
            chiProgress.current = 0;
            chiProgress.GetCurrentFill();
            chiCountText.text = chiCount.ToString();
        }
    }
}
