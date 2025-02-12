using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource characterAudioSource;
    //bool idle = true;
    //bool idleSoundStarted = false;
    [SerializeField] float  timerIdleSoundWait = 5f;
    void Start()
    {
        characterAudioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomIdleSound());
    }

    // Update is called once per frame
    void Update()
    {
        //if (idle && !idleSoundStarted)
        //{
        //    idleSoundStarted = true;
        //    StartCoroutine(PlayRandomIdleSound());
        //}
        //else if(!idle && idleSoundStarted)
        //{
        //   idleSoundStarted = false;
        //   StopCoroutine(PlayRandomIdleSound());
        //}
    }
    IEnumerator PlayRandomIdleSound()
    {
        yield return new WaitForSeconds(timerIdleSoundWait);
        if (characterAudioSource.isActiveAndEnabled && !characterAudioSource.isPlaying)
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
            StartCoroutine(PlayRandomIdleSound());
            //idleSoundStarted = false;
        }
    }
    private void OnMovement()
    {
        //idle = false;
        characterAudioSource.clip = SoundBank.Instance.stepAudio;
        if (characterAudioSource.isPlaying)
            characterAudioSource.UnPause();
        else
            characterAudioSource.Play();
        StopAllCoroutines();
    }

    private void OnMovementStop()
    {
        //idle = true;
        characterAudioSource.Pause();
        StartCoroutine(PlayRandomIdleSound());
    }
}
