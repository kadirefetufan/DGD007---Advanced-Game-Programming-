using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvasıdle : MonoBehaviour
{
    public Transform hedefKonum; 
    public GameObject acilacakCanvas; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            if (other.transform.position == hedefKonum.position)
            {
                
                acilacakCanvas.SetActive(true);
            }
        }
    }
}
