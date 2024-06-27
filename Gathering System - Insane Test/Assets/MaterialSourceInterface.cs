using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MaterialSourceInterface : MonoBehaviour
{
    [SerializeField] MaterialSource source;
    [SerializeField] Button confirmButton;
    [SerializeField] TMP_Text currentInfoText;

    [SerializeField] int gatheringProcess;
    [SerializeField] int resourceAmount;

    public void Interaction()
    {
        GatheringSystemManager manager = GatheringSystemManager.instance;
        InterfaceManager interfaceM = InterfaceManager.instance;

        if (manager.weaponDegradationCopy[manager.GetCurrentWeaponIndex()] >= 100) 
        {
            interfaceM.logConsole.text = "LOG CONSOLE: WEAPON IS BROKEN!";
            return; 
        }

        if (source.IsNegativeInteraction(manager.currentWeapon.damageType))
        {
            confirmButton.interactable = false;
            confirmButton.gameObject.GetComponentInChildren<TMP_Text>().text = "Material Source Destroyed";
            interfaceM.logConsole.text = "LOG CONSOLE: MATERIAL SOURCE DESTROYED!";
            return;
        }

        InteractionType interactionType = source.GetInteraction(manager.currentWeapon.damageType);
        if (interactionType != null)
        {
            int finalEffectviness = (interactionType.effectiveness + manager.currentWeapon.gatheringEffectviness) / 2;

            gatheringProcess += finalEffectviness;

            if(gatheringProcess >= 100)
            {
                int remainingValue = gatheringProcess - 100;
                gatheringProcess = remainingValue;
                resourceAmount--;
                interfaceM.AddResource(source.resource);
            }

            if(resourceAmount == 0)
            {
                confirmButton.interactable = false;
                confirmButton.gameObject.GetComponentInChildren<TMP_Text>().text = "Material Source Depleted";
                interfaceM.logConsole.text = "LOG CONSOLE: MATERIAL SOURCE DEPLETED!";
            }

            manager.DepleteWeapon(interactionType.weaponDegradation);
            UpdateInfo();
        }
        else
        {
            interfaceM.logConsole.text = "LOG CONSOLE: WEAPON TYPE INCOMPATIBLE WITH MATERIAL SOURCE!";
        }
    }

    void UpdateInfo()
    {
        currentInfoText.text = "CURRENT INFORMATION \nGathering Progress: " + gatheringProcess + " / 100 \nMaterial available: " + resourceAmount;
    }
}