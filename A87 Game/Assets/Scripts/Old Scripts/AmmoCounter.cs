using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private GunData gunData;

    public Text changingText;
    public GameObject changingTextTwo;

    public void textChange()
    {
        int ammo = gunData.currentAmmo;
        changingText.text = ammo.ToString();
        changingTextTwo.GetComponent<Text>().text = ammo.ToString();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
