using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInterface : MonoBehaviour
{
    public Weapon weapon;
    public Button button;
    public TMP_Text infoText;

    public void UpdateText(int degradation)
    {
        infoText.text = weapon.weaponName + " \nDamage Type: " + weapon.damageType.ToString() + "\nGathering Effectviness: " + weapon.gatheringEffectviness + " \nDegradation: " + degradation + " / 100";
    }
}