using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummyInteract : MonoBehaviour, IInteractable
{
    [SerializeField] SO_Dialogue TrainingDummyDialogue;
    [SerializeField] SO_Dialogue TrainingDummySecondDialogue;
    bool talkedTo = false;
    public void Interact()
    {
        if (!talkedTo)
        {
            talkedTo = true;
            DialogueManager.Instance.StartDialogue(TrainingDummyDialogue);
        }
        else if (talkedTo)
        {
            DialogueManager.Instance.StartDialogue(TrainingDummySecondDialogue);
        }
            
    }

}
