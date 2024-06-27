using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GatheringSystemManager : MonoBehaviour
{
    public static GatheringSystemManager instance;

    public Weapon currentWeapon;

    public List<Weapon> weapons = new List<Weapon>();
    public List<WeaponInterface> weaponInterface = new List<WeaponInterface>();

    [HideInInspector] public List<int> weaponDegradationCopy = new List<int>();

    private void Awake()
    {
        instance = this;

        foreach(Weapon weapon in weapons)
        {
            weaponDegradationCopy.Add(0);
        }
    }

    public int GetCurrentWeaponIndex()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i] == currentWeapon) { return i; }
        }
        return 0;
    }

    public void DepleteWeapon(int depletionValue)
    {
        int currentWeaponIndex = GetCurrentWeaponIndex();

        WeaponInterface targetWeaponInterface = null;
        foreach (WeaponInterface op in weaponInterface)
        {
            if (op.weapon == currentWeapon)
            {
                targetWeaponInterface = op;
                break;
            }
        }

        weaponDegradationCopy[currentWeaponIndex] += depletionValue;

        targetWeaponInterface.UpdateText(weaponDegradationCopy[currentWeaponIndex]);

        if (weaponDegradationCopy[currentWeaponIndex] >= 100)
        {
            targetWeaponInterface.button.interactable = false;
            targetWeaponInterface.button.GetComponentInChildren<TMP_Text>().text = "Weapon Destroyed";
        }
    }
}