using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedDoor : Sounds
{
    public GameObject ImageText;
    public GameObject TextKey;
    public Animator animator;
    public bool toogle, Interactable;

    [SerializeField] InventoryManager.AllItems _requiredItem;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Interactable = false;
        TextKey.SetActive(false);
    }
    private void OnTriggerStay(Collider door)
    {
        if (door.gameObject.tag == "MainCamera")
        {
            ImageText.SetActive(true);
            Interactable = true;
            if (HasRequiredItem(_requiredItem) == false)
            {
                TextKey.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider door)
    {
        if (door.gameObject.tag == "MainCamera")
        {
            TextKey.SetActive(false);
            ImageText.SetActive(false);
            Interactable = false;
        }
    }
    void Update()
    {        
        if (Interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && HasRequiredItem(_requiredItem))
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
    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
