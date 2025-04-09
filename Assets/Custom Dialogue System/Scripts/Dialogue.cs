using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Dialogue : ScriptableObject
{
    [SerializeField] string title;
    [SerializeField] DialogueNode start;

    public string Title { get { return title; } }
    public DialogueNode Start { get { return start; } }


}
