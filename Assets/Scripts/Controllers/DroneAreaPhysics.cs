using System;
using Enums;
using UnityEngine;

namespace Controllers
{
    
    public class DroneAreaPhysics:MonoBehaviour
    {
        [SerializeField] private DroneColorAreaManager droneColorAreaManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Collected"))
            {
                if (other.GetComponentInParent<CollectableManager>().CurrentColorType == droneColorAreaManager.CurrentColorType)
                {
                    droneColorAreaManager.matchType = MatchType.Match;
                }
                
            }
        }
    }
}