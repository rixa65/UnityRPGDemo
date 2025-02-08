using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TextMeshProUGUI masterValueTxt;
    [SerializeField] TextMeshProUGUI sfxValueTxt;
    [SerializeField] TextMeshProUGUI ambienceValueTxt;
    void Start()
    {
        SetMasterVolume(1f);
        SetSFXVolume(1f);
        SetAmbienceVolume(1f);
    }

    public void SetMasterVolume(float volume)
    {
        int volumeToInt = (int)Mathf.Clamp((volume * 10),0,20);
        masterValueTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        int volumeToInt = (int)Mathf.Clamp((volume * 10), 0, 20);
        sfxValueTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
    public void SetAmbienceVolume(float volume)
    {
        int volumeToInt = (int)Mathf.Clamp((volume * 10), 0, 20);
        ambienceValueTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("AmbienceVolume", Mathf.Log10(volume) * 20);

    }
}
