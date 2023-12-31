using System.Numerics;
using DG.Tweening;
using UnityEngine;
using TMPro;
using Vector3 = UnityEngine.Vector3;

namespace Controllers
{
    public class PlayerTextController : MonoBehaviour
    {

        [SerializeField] private TextMeshPro playerScoreText;

        public void UpdatePlayerScore(float totalScore)
        {
            playerScoreText.text = totalScore.ToString();
        }
        public void CloseScoreText(bool _isClosed)
        {
            if (_isClosed)
            {
                transform.DOScale(Vector3.zero, 0.1f);

            }
            else
            {
                transform.DOScale(Vector3.one, 0.1f);
            }
        }
    }
}

