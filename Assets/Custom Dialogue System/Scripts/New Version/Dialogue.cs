using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueNewVersion
{
	[Serializable]
	public enum DialogueNodeType
	{
		TEXT,
		SELECTION,
		BIFURCATION_EVENT
	}

	[Serializable]
	public class DialogueNode
	{
		public virtual DialogueNodeType type { get; }
	}


	[Serializable]
	public class DialogueTextNode : DialogueNode
	{
		public override DialogueNodeType type { get { return DialogueNodeType.TEXT; } }

		[SerializeField] string text;

		[SerializeField] DialogueNode next;

		public string Text { get { return text; } }

		public DialogueNode Next { get { return next; } }

	}


	public class Dialogue : MonoBehaviour
	{
		public List<DialogueNode> nodes = new List<DialogueNode>();

		public DialogueTextNode testTextNode;
	}

}