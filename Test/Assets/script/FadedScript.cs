using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadedScript : MonoBehaviour
{
    public float faded_speed = 1f;
    
    IEnumerator Start()
    {
        Image fade_image = GetComponent<Image>();
        Color color = fade_image.color;
        
        while(color.a < 1f)
        {
            color.a += faded_speed * Time.deltaTime;
            fade_image.color = color;
            yield return null;
        }
        print("wellDone");
    }
}
