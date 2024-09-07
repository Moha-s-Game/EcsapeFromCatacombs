using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    public GameObject ImageText;
    public new Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            ImageText.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            rigidbody.isKinematic = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            ImageText.SetActive(false);
        }
    }
}
