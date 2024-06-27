using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu]
public class MaterialSource : ScriptableObject
{
    public Resource resource;
    public List<InteractionType> positiveInteractions = new List<InteractionType>();
    public List<InteractionType> negativeInteractions = new List<InteractionType>();

    public bool IsNegativeInteraction(DamageType type)
    {
        foreach(InteractionType target in negativeInteractions)
        {
            if(target.damageType == type)
            {
                return true;
            }
        }
        return false;
    }

    public InteractionType GetInteraction(DamageType type) 
    {
        foreach(InteractionType target in positiveInteractions)
        {
            if(target.damageType == type)
            {
                return target;
            }
        }
        return null;
    }
}

[System.Serializable]
public class InteractionType
{
    public DamageType damageType;
    [Range(0, 100)] public int effectiveness;
    public int weaponDegradation;
}