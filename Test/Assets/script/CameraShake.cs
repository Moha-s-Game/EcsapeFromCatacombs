using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float amount = 1;
    public float speed = 1;

    private Vector3 startPos;
    private float distation;
    private Vector3 rotation = Vector3.zero;
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        distation += (transform.position - startPos).magnitude; 
        startPos = transform.position;
        rotation.z = Mathf.Sin(distation * speed) * amount;
        transform.localEulerAngles = rotation;
        transform.localRotation = Quaternion.Euler(90f, 0f, rotation.z);
    }
}
