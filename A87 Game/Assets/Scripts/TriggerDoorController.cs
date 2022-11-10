using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    //[SerializeField] private bool openTrigger = false;

    private GameObject[] targets;
    public void Update() 
    {
        OntriggerEnter();
        
    }

    private void OntriggerEnter() 
    {
        targets = GameObject.FindGameObjectsWithTag("Objective");
        //Debug.LogError(""+targets.Length);

        if (GameObject.FindGameObjectWithTag("Objective") == null)
        {
            //opendoor
            myDoor.Play("DoorRight", 0, 0.0f);
            myDoor.Play("DoorLeft", 0, 0.0f);
            
        }
        else 
        {
            //do nothing
            //Debug.LogError("There are still Targets");
        }
    }
}
