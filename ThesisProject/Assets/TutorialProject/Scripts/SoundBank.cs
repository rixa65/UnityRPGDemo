using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundBank : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static SoundBank Instance { get; private set; }
    public AudioClip stepAudio;
    public AudioClip creepyWomanLaughterAudio;
    public AudioClip sneezesAudio;
    public AudioClip stomachNoisesAudio;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
