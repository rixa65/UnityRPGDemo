using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummyInteract : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Hello! I am a training dummy");
    }

}
