using System;
using System.Collections.Generic;
using DG.Tweening;
using Enums;
using Signals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class DroneColorAreaManager : MonoBehaviour
    {

        public ColorTypes CurrentColorType;
        public  MatchType matchType=MatchType.UnMatched;

        [SerializeField]bool openDroneAreaExit;
        [SerializeField] private DroneAreaMeshController droneAreaMeshController;


        private List<GameObject> _tempList=new List<GameObject>();
        private MeshRenderer _meshRenderer;
     

        private void Awake()
        {
            GetReferences();
        }

        private void GetReferences()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void OnEnable()
        {
            SubscribeEvents();

        }
        private void OnDisable()
        {
            UnSubscribeEvents();

        }

        void SubscribeEvents()
        {
           
            CoreGameSignals.Instance.onGameInit += OnSetColor;
        }

        private void OnSetColor()
        {
          
           droneAreaMeshController.ChangeAreaColor(CurrentColorType);
        }

        void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onGameInit -= OnSetColor;
        }

    }
}