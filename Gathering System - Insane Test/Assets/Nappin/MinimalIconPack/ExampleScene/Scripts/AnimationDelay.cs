using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationDelay : MonoBehaviour
{
    [Header("Anim specs")]
    public float animDelay = 0.1f;
    
    
    private List<Animator> iconsAnim;
    private Animator rowAnim;


    private void Awake()
    {

        iconsAnim = new List<Animator>();

        for (int i = 0; i < this.transform.GetChild(0).childCount; i++)
        {
            iconsAnim.Add(this.transform.GetChild(0).GetChild(i).GetComponent<Animator>());
            iconsAnim[i].enabled = false;
        }

        rowAnim = this.GetComponent<Animator>();
        rowAnim.enabled = false;
    }


    private void Update()
    {
        animDelay -= 0.01f;

        if (animDelay <= 0)
        {
            rowAnim.enabled = true;
            this.enabled = false;
        }
    }


    public void PlayIconsAnim()
    {
        for (int i = 0; i < iconsAnim.Count; i++) iconsAnim[i].enabled = true;
    }
}