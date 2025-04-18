using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogueNodeType
{
	TEXT,
	SELECTION
}

public abstract class DialogueNode : ScriptableObject
{
	public abstract DialogueNodeType type { get; }
}
