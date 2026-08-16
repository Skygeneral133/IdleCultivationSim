using System;
using TMPro;
using UnityEngine;

public class ChiController : MonoBehaviour
{
    [SerializeField] private float chiCount;

    public TextMeshProUGUI chiCountText;
    public float chiProgressRate;
    public ProgressBar chiProgress;
    public int chiIncreaseRate;

    // Start is called before the first frame update
    private void Start()
    {
        if (chiCountText) chiCountText.text = chiCount.ToString();
        Ticker.OnTick += delegate { UpdateChiCountProgress(); };
    }

    public static event Action<float> OnChiChanged;

    public float GetChiCount()
    {
        return chiCount;
    }

    public void AddChiCount(float value)
    {
        chiCount += value;
        chiCountText.text = chiCount.ToString();
        OnChiChanged?.Invoke(chiCount);
    }

    public void MinusChiCount(float value)
    {
        chiCount -= value;
        chiCountText.text = chiCount.ToString();
        OnChiChanged?.Invoke(chiCount);
    }

    private void UpdateChiCountProgress()
    {
        chiProgress.current += chiProgressRate;
        chiProgress.GetCurrentFill();
        CheckIfChiComplete();
    }

    private void CheckIfChiComplete()
    {
        if (chiProgress.current >= chiProgress.maximum)
        {
            AddChiCount(chiIncreaseRate);
            chiProgress.current = 0;
            chiProgress.GetCurrentFill();
            chiCountText.text = chiCount.ToString();
        }
    }
}