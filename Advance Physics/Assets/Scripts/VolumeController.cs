using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Events;
using System;

public class VolumeController : MonoBehaviour
{
    [SerializeField] string volumeParameter = "Master_volume";
    [SerializeField] AudioMixer aMixer;
    [SerializeField] Slider audioSlider;
    [SerializeField] Toggle toggle;
    public float multiplier;
    void OnEnable()
    {
        PlayerPrefs.SetFloat(volumeParameter, audioSlider.value);
    }
    void Awake()
    {
        audioSlider.onValueChanged.AddListener(HandSliderValueChanged);
        toggle.onValueChanged.AddListener(HandToggledValueChanged);
    }

    void HandToggledValueChanged(bool val)
    {
        if(val)
        {
            audioSlider.value = audioSlider.maxValue;
        }
        else
        {
            audioSlider.value = audioSlider.minValue;
        }
    }

    void HandSliderValueChanged(float value)
    {
        aMixer.SetFloat(volumeParameter, value: Mathf.Log10(value) * multiplier);
        toggle.isOn = audioSlider.value > audioSlider.minValue;
    }

    void Start()
    {
        audioSlider.value = PlayerPrefs.GetFloat(volumeParameter, audioSlider.value);
    }

    void Update()
    {

    }
    //void OnDisable()
    //{
    //    PlayerPrefs.SetFloat(volumeParameter, audioSlider.value);
    //}
}
