using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager instance;
    [SerializeField] TMP_Text currentText, inventoryText;
    public TMP_Text logConsole;

    public List<Resource> resources = new List<Resource>();

    int weaponSelectionIndex = 0;

    private void Awake()
    {
        instance = this;
        SelectWeapon(0);
    }

    public void SelectWeapon(int newIndex)
    {
        GatheringSystemManager manager = GatheringSystemManager.instance;
        weaponSelectionIndex = newIndex;

        manager.currentWeapon = manager.weapons[newIndex];
        switch (weaponSelectionIndex)
        {
            case 0:
                currentText.text = "Current: Sword";
                break;
            case 1:
                currentText.text = "Current: Club";
                break;
            case 2:
                currentText.text = "Current: Bomb";
                break;
            case 3:
                currentText.text = "Current: Hands";
                break;
        }
    }

    public void AddResource(Resource newResource)
    {
        resources.Add(newResource);

        List<string> resourceTypeInInventory = new List<string>();
        foreach(Resource r in resources)
        {
            if (!resourceTypeInInventory.Contains(r.resourceName))
            {
                resourceTypeInInventory.Add(r.resourceName);
            }
        }

        List<string> resourceText = new List<string>();
        foreach(string resourceType in resourceTypeInInventory)
        {
            int resourceAmount = 0;
            foreach(Resource r in resources)
            {
                if(r.resourceName == resourceType)
                {
                    resourceAmount++;
                }
            }

            string newText = resourceAmount + " x " + resourceType + "\n";
            resourceText.Add(newText);
        }

        string finalText = "";
        foreach(string t in resourceText)
        {
            finalText += t;
        }

        inventoryText.text = finalText;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Close()
    {
        Application.Quit();
    }
}