using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVisuia : MonoBehaviour
{   
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }    
}
