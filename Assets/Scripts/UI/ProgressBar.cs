using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float maximum;
    public float current;
    public Image mask;

    private void Start()
    {
        current = 0;
    }

    public void GetCurrentFill()
    {
        var fillAmount = current / maximum;
        mask.fillAmount = fillAmount;
    }
}