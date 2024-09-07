using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : Sounds
{
    public GameObject endding;
    bool Interactablee;
    public GameObject faded;
    public NewCheckPoint newCheck;
    void Start()
    {
        endding.SetActive(false);
        Interactablee = false; 
        faded.SetActive(false);
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
                PlaySound(sounds[0],1);
                endding.SetActive (true);
                Invoke("Faded", 3);
                Invoke("MenuScene", 10);
                PlayerPrefs.SetInt("Last_checkpoint_index", -1);
            }
        }
    }void Faded()
    {
        faded.SetActive (true);
    }
    void MenuScene()
    {        
        SceneManager.LoadScene(0);
    }
}
