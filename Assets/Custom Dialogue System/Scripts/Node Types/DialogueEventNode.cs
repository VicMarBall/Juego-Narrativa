using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueEventNode : DialogueNode
{
	public override DialogueNodeType type { get { return DialogueNodeType.EVENT; } }

	[SerializeField] public UnityEvent nodeEvent;

	[SerializeField] DialogueNode next;

	public DialogueNode Next { get { return next; } }
}