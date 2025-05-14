using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueEventBifurcationNode : DialogueNode
{
	public override DialogueNodeType type { get { return DialogueNodeType.BIFURCATION_EVENT; } }

	[SerializeField] public UnityEvent nodeEvent;
}