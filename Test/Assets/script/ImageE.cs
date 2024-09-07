using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageE : Sounds
{
    public GameObject Hand;
    public GameObject ImageText;
    public Light lightF;
    public bool Interactable;
    public bool canPickUp;

    new Rigidbody rigidbody;

    private void Start()
    {
        lightF.enabled = true;
        ImageText.SetActive(false);
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }
        if (Interactable == false)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Drop();
            }
        }
        if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (canPickUp)
            {
                lightF.enabled = !lightF.enabled;
                PlaySound(sounds[0], 1);
            }
            else
            {
                return;
            }         
        }
    }
    void PickUp()
    {
        if (canPickUp) Drop(); 
        ImageText.SetActive(false);
        Interactable = false;
        rigidbody.isKinematic = true;
        gameObject.transform.rotation = Hand.transform.rotation;
        gameObject.transform.position = Hand.transform.position;
        gameObject.transform.SetParent(Hand.transform);
        canPickUp = true;
    }
    void Drop()
    {
        gameObject.transform.SetParent(null);
        rigidbody.isKinematic = false;
        gameObject.transform.eulerAngles = Vector3.zero;
        rigidbody.AddForce(Camera.main.transform.forward * 200);
        Interactable = true;
        canPickUp = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            ImageText.SetActive(true);
            Interactable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            ImageText.SetActive(false);
            Interactable = false;
        }
    }
}
