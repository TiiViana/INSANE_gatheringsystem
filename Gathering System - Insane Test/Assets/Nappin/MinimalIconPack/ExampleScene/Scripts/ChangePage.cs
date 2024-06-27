using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ChangePage : MonoBehaviour
{
    [Header("Block 1 specs")]
    [Space(15)]
    public GameObject block1;
    public GameObject block1TopButton;
    public GameObject[] page1Content;
    

    [Header("Block 2 specs")]
    [Space(15)]
    public GameObject block2;
    public GameObject block2TopButton;
    public GameObject[] page2Content;


    [Header("Block 3 specs")]
    [Space(15)]
    public GameObject block3;
    public GameObject block3TopButton;
    public GameObject[] page3Content;


    [Header("Event specs")]
    public KeyCode keycode;
    public bool enableSelection = true;
    public bool switchPage = false;

    private EventSystem eventSystem;
    private int currentActive = 1;


    private void Awake()
    {
        eventSystem = EventSystem.current;
    }


    public void Update()
    {
        //change page
        if (Input.GetKeyUp(keycode))
        {
            if (!switchPage)
            {
                currentActive++;
                if (currentActive > 3) currentActive = 1;
            }
            else
            {
                currentActive++;
                if (currentActive > 2) currentActive = 1;
            }

            if (currentActive == 1)
            {
                block1.SetActive(true);
                block2.SetActive(false);
                block3.SetActive(false);

                if (enableSelection)
                {
                    eventSystem.SetSelectedGameObject(block1TopButton);
                    //for (int i = 0; i < page1Content.Length; i++) page1Content[i].SetActive(true);
                    for (int i = 0; i < page2Content.Length; i++) page2Content[i].SetActive(false);
                    for (int i = 0; i < page3Content.Length; i++) page3Content[i].SetActive(false);
                }
            }
            else if (currentActive == 2)
            {
                block1.SetActive(false);
                block2.SetActive(true);
                block3.SetActive(false);

                if (enableSelection)
                {
                    eventSystem.SetSelectedGameObject(block2TopButton);
                    for (int i = 0; i < page1Content.Length; i++) page1Content[i].SetActive(false);
                    //for (int i = 0; i < page2Content.Length; i++) page2Content[i].SetActive(true);
                    for (int i = 0; i < page3Content.Length; i++) page3Content[i].SetActive(false);
                }
            }
            else if (currentActive == 3)
            {
                block1.SetActive(false);
                block2.SetActive(false);
                block3.SetActive(true);

                if (enableSelection)
                {
                    eventSystem.SetSelectedGameObject(block3TopButton);
                    for (int i = 0; i < page1Content.Length; i++) page1Content[i].SetActive(false);
                    for (int i = 0; i < page2Content.Length; i++) page2Content[i].SetActive(false);
                    //for (int i = 0; i < page3Content.Length; i++) page3Content[i].SetActive(true);
                }
            }
        }
    }
}