using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GunData gunData;
    // Start is called before the first frame update
    void Start()
    {
       // PlayerShoot.shootInput += Shoot;
    }

    public void Shoot()
    {
        Debug.Log("Shot Gun");
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
