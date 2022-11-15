using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Automatic Gun", menuName="Guns/Automatic")]
public class Automatic : GunWeapon
{
    
    public float fireRate;
    private float lastTimeFired;
    public GameObject part;

    public override void OnLeftMouseHold(Transform cameraPos, ParticleSystem particles) 
    {
        if (Time.time - lastTimeFired > 1 / fireRate) 
        {
            lastTimeFired = Time.time;
            Fire(cameraPos, particles);
            //part = particles;
            //flash();
            //particles.SetActive(true);
            //particles.SetActive(false);
            //mFlash();
            //particles.Stop();
            //particles.Play();
        }

    }
    private void OnDisable() 
    {
        lastTimeFired = 0f;
        //particles.setActive(false);
    }

    IEnumerator flash()
    {
        part.SetActive(true);
        yield return new WaitForSeconds(fireRate);
        part.SetActive(false);
    }
}
