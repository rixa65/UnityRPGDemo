using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour, IInteractable
{
    [SerializeField] string itemName;
    public void Interact()
    {
        EventController.Instance.TriggerOnQuestItemInteracted(itemName);
        Destroy(gameObject);
    }

}
