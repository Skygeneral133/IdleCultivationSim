using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class panelButton : MonoBehaviour
    {
        public GameObject panel;
        public Button button;
        public panelController panelController;

        private void Start()
        {
            button.onClick.AddListener(() =>
                {
                    panelController.ShowOnly(panel);
                }
            );
        }
        private void Update()
        {
            if (panel.activeSelf)
            {
                button.interactable = false;
            }
            else 
            {
                button.interactable = true;
            }
        }
    }
}