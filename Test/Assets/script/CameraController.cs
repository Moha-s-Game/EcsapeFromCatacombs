using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Sensitivity = 2.0f;
    public float MaxYAngle = 80f;
    public GameObject Menu;
    private float rotationX = 0f;
    public static bool isPaused = true;
    public float amount = 1;
    public float speed = 1;

    private Vector3 startPos;
    private float distation;
    private Vector3 rotation = Vector3.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        startPos = transform.position;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(Vector3.up * mouseX * Sensitivity);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            amount = 2.2f;
            speed = 1.2f;
        }else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            amount = 1.2f;
            speed = 1.2f;
        }

        rotationX -= mouseY * Sensitivity;
        rotationX = Mathf.Clamp(rotationX, -MaxYAngle, MaxYAngle);
        distation += (transform.position - startPos).magnitude;
        startPos = transform.position;
        rotation.z = Mathf.Sin(distation * speed) * amount;
        transform.localEulerAngles = rotation;
        transform.localRotation = Quaternion.Euler(rotationX, 0f, rotation.z);        
    }
}
