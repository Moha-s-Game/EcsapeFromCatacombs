using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saving : MonoBehaviour
{
    public Transform PlayerPose;
    [SerializeField]float x, y, z;
    void Start()
    {
        Load();
        Save();
    }
    private void Update()
    {
        Save();
    }
    void Save()
    {
        x = PlayerPose.transform.position.x;
        y = PlayerPose.transform.position.y;
        z = PlayerPose.transform.position.z;

        PlayerPrefs.SetFloat("Save X", x);
        PlayerPrefs.SetFloat("Save Y", y);
        PlayerPrefs.SetFloat("Save Z", z);
    }
    public void Load()
    {
        if(PlayerPrefs.HasKey("Save X"))
        {
            x = PlayerPrefs.GetFloat("Save X");
        }
        if (PlayerPrefs.HasKey("Save Y"))
        {
            y = PlayerPrefs.GetFloat("Save Y");
        }
        if (PlayerPrefs.HasKey("Save Z"))
        {
            z = PlayerPrefs.GetFloat("Save Z");
        }        
        PlayerPose.position = new Vector3(x, y, z);
    }
}
