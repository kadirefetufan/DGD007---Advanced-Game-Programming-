using System;
using Enums;
using UnityEngine;
using Managers;
using Signals;
using Controllers;

public class PlayerPhysicsController : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private new Collider collider;
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private GameObject playerObj;

    private bool _isEnteredRainbow = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DroneArea"))
        {
            playerManager.CloseScoreText(true);

        }

        if (other.CompareTag("Market"))
        {
            playerManager.ChangeAnimation(PlayerAnimationTypes.Throw);
        }

        if (other.CompareTag("DroneAreaPhysics"))
        {
            playerManager.RepositionPlayerForDrone(other.gameObject);
            playerManager.EnableVerticalMovement();
        }
        if (other.CompareTag("Portal"))
        {
            StackSignals.Instance.onColorChange?.Invoke(other.GetComponent<ColorController>().ColorType);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DroneArea"))
        {
            playerManager.StopVerticalMovement();
        }
        if (other.CompareTag("Roulette"))
        {
            if (_isEnteredRainbow == false)
            {
                ScoreSignals.Instance.onAddLevelTototalScore?.Invoke();
                playerManager.StopAllMovement();
                playerManager.ActivateMesh();
                _isEnteredRainbow = true;
            }
            
        }
    }
}


