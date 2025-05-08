using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueNewVersion
{
	[Serializable]
	public class DialogueTextNodeComponent : DialogueNodeComponent
	{
		public override DialogueNodeType type { get { return DialogueNodeType.TEXT; } }

		[SerializeField] string text;

		[SerializeField] DialogueNodeComponent next;

		public string Text { get { return text; } }

		public DialogueNodeComponent Next { get { return next; } }

	}

}