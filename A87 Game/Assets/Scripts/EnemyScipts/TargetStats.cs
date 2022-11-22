using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Target Stats", menuName = "Target/Stats")]

public class TargetStats : ScriptableObject
{
    public string enemyName;
    public int maxHealth;
}