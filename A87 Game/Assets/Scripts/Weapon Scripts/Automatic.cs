using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Automatic Gun", menuName="Guns/Automatic")]
public class Automatic : GunWeapon
{
    
    public float fireRate;
    private float lastTimeFired;

    public override void OnLeftMouseHold(Transform cameraPos) 
    {
        if (Time.time - lastTimeFired > 1 / fireRate) 
        {
            lastTimeFired = Time.time;
            Fire(cameraPos);
        }
        
    }
    private void OnDisable() 
    {
        lastTimeFired = 0f;
    }
}
