using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Teleportation : MonoBehaviour
{  public GameObject currentPortal;
    [SerializeField]
    private InputManager inputManager;
        private void FixedUpdate()
        {
            CheckTeleportInput();
        }
        private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Portal")){
            currentPortal=other.gameObject;
             
        }
    
    }
     private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Portal")){
            if(other.gameObject==currentPortal)
            { 
                currentPortal=null;
            }

        }
    
    }
    IEnumerator Teleport(){
         yield return new WaitForSeconds(0.5f);
         if(currentPortal!=null)
         {
            transform.position=currentPortal.GetComponent<Portal>().GetDestination().position;
         }
    }
    private void CheckTeleportInput()
    {
        if (inputManager != null)
        {
            if (inputManager.teleportButton == 1)
            {
                 StartCoroutine(Teleport());
                 //Consume the input
                inputManager.teleportButton = 0;
        }
        }
    }
}
