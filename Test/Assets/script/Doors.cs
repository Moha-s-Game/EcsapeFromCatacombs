using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Sounds
{
    public GameObject ImageText;
    public Animator animator;
    public bool toogle, Interactable;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Interactable = false;
    }
    private void OnTriggerStay(Collider door)
    {
        if (door.gameObject.tag == "MainCamera")
        {
            ImageText.SetActive(true);
            Interactable = true;
        }
    }
    private void OnTriggerExit(Collider door)
    {
        if (door.gameObject.tag == "MainCamera")
        {
            ImageText.SetActive(false);
            Interactable = false;
        }
    }
    void Update()
    {
        if (Interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toogle = !toogle;
                if (toogle == true)
                {
                    PlaySound(sounds[0], 1);
                    animator.ResetTrigger("isClose");
                    animator.SetTrigger("isOpen");
                }
                if (toogle == false)
                {
                    PlaySound(sounds[1], 1);
                    animator.ResetTrigger("isOpen");
                    animator.SetTrigger("isClose");
                }
            }
        }
    }
}
