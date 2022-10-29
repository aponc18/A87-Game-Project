using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prevLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Application.LoadLevel("TestScene1");
        }
    }
}
