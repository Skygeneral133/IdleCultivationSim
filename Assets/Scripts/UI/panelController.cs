using UnityEngine;

public class panelController : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject startPanel;

    private void Start()
    {
        ShowOnly(startPanel);
    }


    public void ShowOnly(GameObject panel)
    {
        foreach (var panel2 in panels)
        {
            if (panel == panel2)
                panel.SetActive(true);
            else
                panel2.SetActive(false);
            ;
        }
    }
}