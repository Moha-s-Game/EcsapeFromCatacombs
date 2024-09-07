using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : Sounds
{
    public GameObject JumpScareObj;
    void Start()
    {
        JumpScareObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            JumpScareObj.SetActive(true);
            StartCoroutine(DestroyGameObj());
            PlaySound(sounds[0], 2);
        }
    }
    IEnumerator DestroyGameObj()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(JumpScareObj);
        Destroy(gameObject);
    }
}
