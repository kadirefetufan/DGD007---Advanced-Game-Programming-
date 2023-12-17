using TMPro;
using UnityEngine;

namespace Controllers
{
    public class LevelPanelController:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelText;
        public void SetLevelText(int value)
        {
            int _levelValue=value + 1;
            Debug.Log("_levelValue"+_levelValue);
            levelText.text = "LEVEL " + (_levelValue + 1).ToString();
        }
    }
}