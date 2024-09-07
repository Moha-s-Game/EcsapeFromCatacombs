using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : ImageE
{
    void Update()
    {
        if (Interactable == false)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Drop();
            }
        }
    }
    void Drop()
    {
        gameObject.transform.DetachChildren();
        gameObject.transform.eulerAngles = Vector3.zero;
        Interactable = false;
    }
}
