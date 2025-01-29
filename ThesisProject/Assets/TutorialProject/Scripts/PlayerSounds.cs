using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource characterAudioSource;
    void Start()
    {
        characterAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMovement()
    {
        characterAudioSource.clip = SoundBank.Instance.stepAudio;
    }
}
