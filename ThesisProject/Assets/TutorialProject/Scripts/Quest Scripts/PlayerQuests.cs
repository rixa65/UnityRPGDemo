using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuests : MonoBehaviour
{
    List<Quest> quests = new List<Quest>();


    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
    }
    public void CheckQuests()
    {
        foreach (Quest quest in quests)
        {
            if (quest.isActive)
            {
                if(quest.CheckCompletion())
                {
                    quest.CompleteQuest();
                }
            }
        }
    }
}
