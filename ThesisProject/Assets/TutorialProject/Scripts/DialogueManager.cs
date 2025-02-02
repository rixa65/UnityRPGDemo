using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }
    public bool InDialogue {  get; private set; }
    bool typing = false;
    Queue<SO_Dialogue.Info> dialogueQueue = new Queue<SO_Dialogue.Info>();
    string wholeText;
    [SerializeField] float textDelay;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject dialogueBoxText;
    // Start is called before the first frame update
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
    public void StartDialogue(SO_Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        InDialogue = true;
        QueueDialogue(dialogue);
        DeQueueDialogue();
            
    }
    private void OnInteract()
    {
        if(InDialogue)
            DeQueueDialogue();
    }
    private void DeQueueDialogue()
    {
        if (typing)
        {
            CompleteText();
            StopAllCoroutines();
            typing = false;
            return;
        }
        if(dialogueQueue.Count == 0)
        {
            
            EndDialogue();
            return;
        }
        
        SO_Dialogue.Info dialogueInfo = dialogueQueue.Dequeue();
        StartCoroutine(TypeText(dialogueInfo));
    }
    private void QueueDialogue(SO_Dialogue dialogue)
    {
        foreach (SO_Dialogue.Info line in dialogue.dialogueInfo)
        {
            dialogueQueue.Enqueue(line);
        }

    }
    private void CompleteText()
    {
        dialogueBoxText.GetComponent<TextMeshProUGUI>().text = wholeText;
    }
    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().enabled = true;
        InDialogue = false;
    }

    IEnumerator TypeText(SO_Dialogue.Info dialogueInfo)
    {
        typing = true;
        dialogueBoxText.GetComponent<TextMeshProUGUI>().text = "";
        wholeText = dialogueInfo.dialogue;
        foreach (char c in dialogueInfo.dialogue)
        {
            dialogueBoxText.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(textDelay);
        }
        typing = false;


    }
}
