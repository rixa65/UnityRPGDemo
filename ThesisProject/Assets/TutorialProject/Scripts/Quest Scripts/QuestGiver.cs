using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestGiver : MonoBehaviour, IInteractable
{
    GameObject playerObject;
    public Quest quest;
    [SerializeField] GameObject questWindow;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI rewardText;
    public void Interact()
    {
        OpenQuestWindow();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        foreach (Goal goal in quest.goalList)
        {
            goal.Init();
        }
    }
    void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        rewardText.text = "Reward: "+quest.reward;
        playerObject.GetComponent<PlayerInput>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
        playerObject.GetComponent<PlayerInput>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void AcceptQuest()
    {
        playerObject.GetComponent<PlayerQuests>().AddQuest(quest);
        quest.isActive = true;
        playerObject.GetComponent<PlayerQuests>().CheckQuests();
    }
}
