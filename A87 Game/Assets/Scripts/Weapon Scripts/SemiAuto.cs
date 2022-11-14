using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SemiAuto Gun", menuName = "Guns/SemiAuto")]
public class SemiAuto : GunWeapon
{
    public override void OnLeftMouseDown(Transform cameraPos)
    {
        Fire(cameraPos);
    }
}