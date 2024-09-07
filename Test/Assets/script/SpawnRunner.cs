using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRunner : MonoBehaviour
{
    public GameObject Runner;
    bool Interactable;
    void Start()
    {
        Runner.SetActive(false);
    }
    private void FixedUpdate()
    {
        if( Interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Runner.SetActive (true);
            }
        }
    }
    private void OnTriggerStay(Collider door)
    {
        if (door.gameObject.tag == "MainCamera")
        {
            Interactable = true;
        }
    }
    private void OnTriggerExit(Collider door)
    {
        if (door.gameObject.tag == "MainCamera")
        {
            Interactable = false;
        }
    }

}
