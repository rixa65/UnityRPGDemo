using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{

    public string title;
    public string description;
    public string reward;
    public List<Goal> goalList;
    public bool isActive;

    public void CompleteQuest()
    {
        isActive = false;
        Debug.Log("You did a quest!");
    }
    public bool CheckCompletion()
    {
        foreach (Goal goal in goalList)
        {
            if(!goal.Completed)
            {
                return false;
            }
        }
        return true;
    }
}
