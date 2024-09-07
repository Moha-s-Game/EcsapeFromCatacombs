using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    public GameObject ImageText;
    public GameObject NameText;
    public bool Interactable;
    [SerializeField] InventoryManager.AllItems _itemType;

    private void Start()
    {
        Interactable = false;
        NameText.SetActive(false);
    }
    private void Update()
    {
        if (Interactable == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                InventoryManager.Instance.AddItem(_itemType);
                Destroy(gameObject);
                ImageText.SetActive(false);
                NameText.SetActive(false);
            }
        }
    }
    private void OnTriggerStay(Collider door)
    {
        if (door.gameObject.tag == "MainCamera")
        {
            ImageText.SetActive(true);
            NameText.SetActive(true); 
            Interactable = true;
        }
    }
    private void OnTriggerExit(Collider door)
    {
        if (door.gameObject.tag == "MainCamera")
        {
            ImageText.SetActive(false);
            NameText.SetActive(false);
            Interactable = false;
        }
    }
}
