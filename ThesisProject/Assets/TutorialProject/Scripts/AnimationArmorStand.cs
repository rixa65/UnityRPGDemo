using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationArmorStand : MonoBehaviour, IInteractable
{
    Animation charactherAnimation;
    public void Interact()
    {
        if(!charactherAnimation.isPlaying)
        {
            charactherAnimation.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        charactherAnimation = GetComponent<Animation>();
    }

}
