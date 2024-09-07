using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public Transform player;
    public Transform flashlight;
    public int index;
    public BoxCollider checkPointCollider;
    private const string SAVE_CHECKPOINT_INDEX = "Last_checkpoint_index";
    void Awake()
    {
        Load();
    }
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (index > Respawn.checkPointIndex)
            {
                Respawn.checkPointIndex = index;
            }
            checkPointCollider.enabled = !checkPointCollider.enabled;
        }
    }
    void Load()
    {
        if (Respawn.checkPointIndex == index)
        {
            player.position = transform.position;
            flashlight.position = player.position;
        }
    }
}
