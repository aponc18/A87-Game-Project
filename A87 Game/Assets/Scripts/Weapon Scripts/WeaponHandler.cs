using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private List<GunWeapon> guns = new List<GunWeapon>();
    //[SerializeField] private GameObject particles;
    [SerializeField] public ParticleSystem particles;
    [SerializeField] public AudioSource arSound;
    [SerializeField] public AudioSource shotSound;
    [SerializeField] public AudioSource pistolSound;


    private GunWeapon currentGun;
    private Transform cameraTransform;
    private GameObject currentGunPrefab;

    private void Start() 
    {
        cameraTransform = Camera.main.transform;
        currentGunPrefab = Instantiate(guns[0].gunPrefab, transform);
        currentGun = guns[0];
    }

    private void Update() 
    {
        if (!PauseMenu.isPaused)
        {
            CheckForShooting();
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Destroy(currentGunPrefab);
                currentGunPrefab = Instantiate(guns[0].gunPrefab, transform);
                currentGun = guns[0];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Destroy(currentGunPrefab);
                currentGunPrefab = Instantiate(guns[1].gunPrefab, transform);
                currentGun = guns[1];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Destroy(currentGunPrefab);
                currentGunPrefab = Instantiate(guns[2].gunPrefab, transform);
                currentGun = guns[2];
            }
        }
    }

    private void CheckForShooting()
    {
        if (currentGun == guns[2])
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentGun.OnLeftMouseDown(cameraTransform, particles);
                particles.Stop();
                particles.Play();
                shotSound.Stop();
                shotSound.Play();
            }
        }
        if (currentGun == guns[0])
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentGun.OnLeftMouseDown(cameraTransform, particles);
                particles.Stop();
                particles.Play();
                pistolSound.Stop();
                pistolSound.Play();
            }
        }
        if (currentGun == guns[1])
        {
            if (Input.GetMouseButton(0))
            {
                currentGun.OnLeftMouseHold(cameraTransform, particles);
                particles.Stop();
                particles.Play();
                arSound.Stop();
                arSound.Play();
            }
        }
    }
}
