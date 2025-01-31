using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource characterAudioSource;
    bool idle = true;
    float timerIdleSound = 0f;
    [SerializeField] float  timerIdleSoundWait = 5f;
    void Start()
    {
        characterAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (idle)
        {
            timerIdleSound += Time.fixedDeltaTime;

            if (timerIdleSound >= timerIdleSoundWait)
            {
                timerIdleSound -= timerIdleSoundWait;
                PlayRandomIdleSound();
            }
        }
        else if(timerIdleSound != 0f) 
        {
            timerIdleSound = 0f;
        }
    }
    private void PlayRandomIdleSound()
    {
        if (!characterAudioSource.isPlaying)
        {
            int randomNumber = Random.Range(0, 3);
            switch (randomNumber)
            {
                case 0:
                    characterAudioSource.clip = SoundBank.Instance.creepyWomanLaughterAudio;
                    break;
                case 1:
                    characterAudioSource.clip = SoundBank.Instance.stomachNoisesAudio;
                    break;
                case 2:
                    characterAudioSource.clip = SoundBank.Instance.sneezesAudio;
                    break;
            }
            characterAudioSource.Play();
        }
            
    }
    private void OnMovement()
    {
        idle = false;
        characterAudioSource.clip = SoundBank.Instance.stepAudio;
        if (characterAudioSource.isPlaying)
            characterAudioSource.UnPause();
        else
            characterAudioSource.Play();

    }

    private void OnMovementStop()
    {
        idle = true;
        characterAudioSource.Pause();

    }
}
