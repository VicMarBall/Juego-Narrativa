using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueSelectionNode : DialogueNode
{
	public override DialogueNodeType type { get { return DialogueNodeType.SELECTION; } }

	[Serializable]
    public struct Selection
    {
        [SerializeField] public string text;
		[SerializeField] public DialogueNode next;
    }

    [SerializeField] Selection[] selections;

    public Selection[] Selections {  get { return selections; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
