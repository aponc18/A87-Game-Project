using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject targetDestination;
    public GameObject player;

    void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.CompareTag("Teleporter")) 
        {
            player.transform.position = targetDestination.transform.position;
        }
        
        //Random.Range(-10f, 10f), Col.transform.position.y, Random.Range(-10f, 10f)
    }
}
