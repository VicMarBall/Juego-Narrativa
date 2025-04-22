using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueEventBridge : ScriptableObject
{
    public void GetItem(int item) { }

    public void FirstQueenConversationHappiness(int amount) { FindObjectOfType<FirstQueenConversation>()?.ChangeHappiness(amount); }
}
