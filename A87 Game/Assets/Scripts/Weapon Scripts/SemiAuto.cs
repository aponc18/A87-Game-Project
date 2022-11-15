using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SemiAuto Gun", menuName = "Guns/SemiAuto")]
public class SemiAuto : GunWeapon
{
    public GameObject part;

    public override void OnLeftMouseDown(Transform cameraPos, ParticleSystem particles)
    {
        Fire(cameraPos, particles);
        //part = particles;
        //flash();
        //particles.SetActive(true);
        //particles.SetActive(false); 
        //mFlash();
        //particles.Stop();
        //particles.Play();
    }

    IEnumerator flash() 
    {
        part.SetActive(true);
        yield return new WaitForSeconds(1);
        part.SetActive(false);
    }
    
}