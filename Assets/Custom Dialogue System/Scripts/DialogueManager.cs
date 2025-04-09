using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    #region SINGLETON
    public static DialogueManager instance;
    public static DialogueManager Instance 
    { 
        get 
        { 
            if (instance == null) 
                instance = FindObjectOfType<DialogueManager>(); 

            return instance; 
        } 
    }

    #endregion

    [SerializeField] TMP_Text dialogueText;

    Dialogue currentDialogue;
    DialogueNode currentDialogueNode;

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        currentDialogueNode = dialogue.Start;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (currentDialogue == null || currentDialogueNode == null) { EndDialogue(); }

        dialogueText.text = currentDialogueNode.Text;
    }

    public void NextNode()
    {
        currentDialogueNode = currentDialogueNode.Next;
        UpdateUI();
    }

    void EndDialogue()
    {
        dialogueText.text = "";
        currentDialogue = null;
        currentDialogueNode = null;
    }
}
