using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogueNodeType
{
	TEXT,
	SELECTION,
	BIFURCATION_EVENT
}

public abstract class DialogueNode : MonoBehaviour
{
	public abstract DialogueNodeType type { get; }
}
