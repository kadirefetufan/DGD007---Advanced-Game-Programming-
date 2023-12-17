using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Controllers
{
    public class UIPanelController: MonoBehaviour
    {

        [SerializeField] private List<GameObject> panels;

        public void OpenPanel(UIPanelTypes panelParam)
        {
            panels[(int)panelParam].SetActive(true);
        }
        public void ClosePanel(UIPanelTypes panelParam)
        {
            panels[(int)panelParam].SetActive(false);
        }
    }
}