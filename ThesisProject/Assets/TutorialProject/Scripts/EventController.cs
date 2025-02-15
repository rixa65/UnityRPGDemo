using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static EventController Instance { get; private set; }
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
    public Action<string> OnQuestItemInteracted;
    public void TriggerOnQuestItemInteracted(string name)
    {
        OnQuestItemInteracted?.Invoke(name);
    }

}
