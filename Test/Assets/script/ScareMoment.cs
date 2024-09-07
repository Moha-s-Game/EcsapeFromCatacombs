using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareMoment : MonoBehaviour
{
    public GameObject JumpScareObj;
    new public GameObject light;
    void Start()
    {
        JumpScareObj.SetActive(false);
        light.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            light.SetActive(true);
            JumpScareObj.SetActive(true);
            StartCoroutine(DestroyGameObj());
        }
    }
    IEnumerator DestroyGameObj()
    {
        yield return new WaitForSeconds(5.2f);
        Destroy(JumpScareObj);
        Destroy(light);
        Destroy(gameObject);
    }
}
