using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;

    private void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("bgm", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
    }
}
