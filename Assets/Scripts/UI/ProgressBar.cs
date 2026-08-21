using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float maximum;
    public float current = 0;
    public Image mask;
    

    public void GetCurrentFill()
    {
        var fillAmount = current / maximum;
        mask.fillAmount = fillAmount;
    }
}