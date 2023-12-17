using UnityEngine;
using Data.UnityObjects;
using Data.ValueObjects;
using Controllers;
using Keys;
using Enums;
using System.Collections;
using System.Collections.Generic;
using Signals;
using System;

public class PlayerManager : MonoBehaviour
{
    public float CurrentScore;

    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField]private PlayerPhysicsController playerPhysicsController;
    [SerializeField]private PlayerAnimationController playerAnimationController;
    [SerializeField] private PlayerMeshController playerMeshController;
    [SerializeField] private PlayerTextController playerTextController;
    [SerializeField] private ColorTypes _currentColor;


    private PlayerData Data;
    private GameStates _currentGameState = GameStates.Runner;


    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
       
        InputSignals.Instance.onIdleInputTaken += OnGetIdleInputValues;
        ScoreSignals.Instance.onUpdateScore += OnUpdateScoreText;       
        InputSignals.Instance.onInputDragged += OnGetInputValues;
        CoreGameSignals.Instance.onPlay += OnPlay;
        CoreGameSignals.Instance.onReset += OnReset;
        CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
        CoreGameSignals.Instance.onLevelFailed += OnLevelFailed;
        CoreGameSignals.Instance.onGetGameState += OnChangeGameState;
        PlayerSignal.Instance.onChangeVerticalSpeed += OnChangeVerticalSpeed;
        PlayerSignal.Instance.onIncreaseScale += OnIncreaseSize;
        InputSignals.Instance.onSidewaysEnable += OnSidewaysEnable;
       
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void UnSubscribeEvents()
    {
        InputSignals.Instance.onIdleInputTaken += OnGetIdleInputValues;
        InputSignals.Instance.onInputDragged -= OnGetInputValues;
        ScoreSignals.Instance.onUpdateScore -= OnUpdateScoreText;
        CoreGameSignals.Instance.onPlay -= OnPlay;
        CoreGameSignals.Instance.onReset -= OnReset;
        CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
        CoreGameSignals.Instance.onLevelFailed -= OnLevelFailed;
        CoreGameSignals.Instance.onGetGameState -= OnChangeGameState;
        PlayerSignal.Instance.onChangeVerticalSpeed -= OnChangeVerticalSpeed;
        PlayerSignal.Instance.onIncreaseScale -= OnIncreaseSize;
        InputSignals.Instance.onSidewaysEnable -= OnSidewaysEnable;
        
    }

    private void Awake()
    {
        Data = GetPlayerData();
        SendPlayerDataToMovementController();

    }

    private void OnChangeGameState(GameStates arg0)
    {
        //throw new NotImplementedException();

        playerMovementController.CurrentGameState = arg0;
        _currentGameState = arg0;
        if (arg0 == GameStates.Idle)
        {
            playerMovementController.EnableIdleMovement();
        }
    }

    private void SendPlayerDataToMovementController()
    {
        playerMovementController.SetMovementData(Data.PlayerMovementData);
    }

    private PlayerData GetPlayerData() => Resources.Load<CD_Player>("Data/CD_Player").PlayerData;

    private void OnActivateMovement()
    {
        playerMovementController.EnableMovement();
    }

    private void OnDeactivateMovement()
    {
        playerMovementController.DisableMovement();
    }

    private void OnGetInputValues(RunnerHorizontalInputParams inputParam)
    {
        playerMovementController.UpdateRunnerInputValue(inputParam);
    }
    private void OnGetIdleInputValues(IdleInputParams inputParam)
    {
        playerMovementController.UpdateIdleInputValue(inputParam);
    }
    private void OnPlay()
    {
        playerMovementController.EnableMovement();
    }
    private void OnLevelSuccessful()
    {
        playerMovementController.IsReadyToPlay(false);
    }

    private void OnLevelFailed()
    {
        playerMovementController.IsReadyToPlay(false);
    }
    public void StopVerticalMovement()
    {
        playerMovementController.ChangeVerticalMovement(0);
    }

    public void ChangeAnimation(PlayerAnimationTypes _animationType)
    {
        playerAnimationController.ChangeAnimation(_animationType);
    }
    public void StopAllMovement()
    {
        playerMovementController.StopAllMovement();
        ChangeAnimation(PlayerAnimationTypes.Idle);
    }
    public void EnableVerticalMovement()
    {
        playerMovementController.ChangeVerticalMovement(10);
    }

    public void RepositionPlayerForDrone(GameObject _other)
    {
        playerMovementController.RepositionPlayerForDrone(_other);
    }
    public void OnChangeVerticalSpeed(float _verticalSpeed)
    {
        playerMovementController.ChangeVerticalMovement(_verticalSpeed);
    }

    public void OnSidewaysEnable(bool isSidewayEnable)
    {
        playerMovementController.SetSidewayEnabled(isSidewayEnable);
    }

    private void OnReset()
    {
       
        playerMovementController.OnReset();
    }

    public void OnIncreaseSize()
    {
        playerMeshController.IncreasePlayerSize();
    }
    public void ActivateMesh()
    {
        NewCameraSignals.Instance.onChangeCameraState.Invoke(CameraStates.StartOfIdle);
        playerMeshController.ActiveMesh();
    }

    public void OnUpdateScoreText(List<int> _currentScores)
    {
        switch (_currentGameState)
        {
            case GameStates.Idle:                
                playerTextController.UpdatePlayerScore(_currentScores[0]);
                break;
            case GameStates.Runner:
                playerTextController.UpdatePlayerScore(_currentScores[1]);

                break;
            case GameStates.Failed:
                CloseScoreText(true);
                StopAllMovement();

                break;

        }

    }

    public void OnIdleMovement()
    {

    }

    public void CloseScoreText(bool _visiblitystate)
    {
        playerTextController.CloseScoreText(_visiblitystate);
    }





}
