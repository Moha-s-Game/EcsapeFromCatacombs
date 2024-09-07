using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    public float oldVolume;
    void Start()
    {
        oldVolume = slider.value;
        if (!PlayerPrefs.HasKey("volume")) slider.value = 1f;
        else slider.value = PlayerPrefs.GetFloat("volume");
    }

    void Update()
    {
        if (oldVolume != slider.value)
        {
            PlayerPrefs.SetFloat("volume", slider.value);
            PlayerPrefs.Save();            
            oldVolume = slider.value;
        }
    }
}
