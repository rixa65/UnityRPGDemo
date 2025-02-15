using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[System.Serializable]
public class Goal   
{
    public GoalCondition goalCondition;
    public string objectiveName;
    int currentAmount;
    public int requiredAmount;
    public bool Completed { get; private set; }

    public void Init()
    {
        
        switch (goalCondition)
        {
            case GoalCondition.Interact:
                EventController.Instance.OnQuestItemInteracted += ObjectInteracted;
                break;
        }
       
    }
    void CheckGoal()
    {
        if(currentAmount == requiredAmount)
        {
            Completed = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerQuests>().CheckQuests();
            Debug.Log("You did A goal!");
        }
    }
    void ObjectInteracted(string objectName)
    {
        if(objectName == objectiveName)
        {
            currentAmount++;
            CheckGoal();
        }
    }
}
public enum GoalCondition
{
    Interact,
}