using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fun", menuName = "GunWeapon")]
public class GunWeapon : ScriptableObject
{
    public GameObject gunPrefab;
    [Header("Stats")]
    public string gunName;
    public int minDamage;
    public int maxDamage;
    public float maxRange;

}
