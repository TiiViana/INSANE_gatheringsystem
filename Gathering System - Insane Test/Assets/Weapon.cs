using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public DamageType damageType;
    [Range(0, 100)] public int gatheringEffectviness;
    public int weaponDegradation = 100;
}
