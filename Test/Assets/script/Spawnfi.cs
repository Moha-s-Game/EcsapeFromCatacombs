using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnfi : MonoBehaviour
{
    public GameObject endding;
    bool Interactablee;
    void Start()
    {
        endding.SetActive(false);
        Interactablee = false;
    }

    private void OnTriggerStay(Collider door)
    {
        if (door.gameObject.tag == "MainCamera")
        {
            Interactablee = true;
        }
    }
    private void OnTriggerExit(Collider door)
    {
        if (door.gameObject.tag == "MainCamera")
        {
            Interactablee = false;
        }
    }
    void Update()
    {
        if (Interactablee == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                endding.SetActive(true);

            }
        }
    }
}
