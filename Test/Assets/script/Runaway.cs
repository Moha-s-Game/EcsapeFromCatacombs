using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runaway : MonoBehaviour
{
    public GameObject runner;
    void Start()
    {
        runner.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            runner.SetActive(true);
            StartCoroutine(DestroyGameObj());
        }
    }
    IEnumerator DestroyGameObj()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
