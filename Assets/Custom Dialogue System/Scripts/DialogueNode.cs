using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DialogueNode : ScriptableObject
{
    [SerializeField] string text;
    [SerializeField] DialogueNode next;

    public string Text { get { return text; } }
    public DialogueNode Next { get { return next; } }

}
