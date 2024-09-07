using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject _checkpointsParent;
    public GameObject[] _checkPointsArray;
    private Vector3 _startingPoint;

    //todo Uncomment this code if you have a rigidbody on your player and you want to stop it from moving
    // private Rigidbody _rigidbody;

    private const string SAVE_CHECKPOINT_INDEX = "Last_checkpoint_index";

    private void Awake()
    {       
        LoadCheckpoints();
    }

    void Start()
    {
        int savedCheckpointIndex = -1;
        savedCheckpointIndex = PlayerPrefs.GetInt(SAVE_CHECKPOINT_INDEX, -1);
        if (savedCheckpointIndex != -1)
        {
            _startingPoint = _checkPointsArray[savedCheckpointIndex].transform.position;
        }
        else
        {
            _startingPoint = gameObject.transform.position;
        }

        RespawnPlayer();
    }

    void Update()
    {
        if (transform.position.y <= -10f)                
        {
            RespawnPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            int checkPointIndex = -1;
            checkPointIndex = Array.FindIndex(_checkPointsArray, match => match == other.gameObject);

            if (checkPointIndex != -1)
            {
                PlayerPrefs.SetInt(SAVE_CHECKPOINT_INDEX, checkPointIndex);
                _startingPoint = other.gameObject.transform.position;
                other.gameObject.SetActive(false);
            }
        }
    }

    private void RespawnPlayer()
    {
        gameObject.transform.position = _startingPoint;
    }

    private void LoadCheckpoints()
    {
        _checkPointsArray = new GameObject[_checkpointsParent.transform.childCount];

        int index = 0;

        foreach (Transform singleCheckpoint in _checkpointsParent.transform)
        {
            _checkPointsArray[index] = singleCheckpoint.gameObject;
            index++;
        }
    }
}
