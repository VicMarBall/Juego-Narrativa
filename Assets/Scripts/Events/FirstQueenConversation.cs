using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstQueenConversation : MonoBehaviour
{
	[SerializeField] public DialogueNode goodEnding;
	[SerializeField] public DialogueNode midEnding;
	[SerializeField] public DialogueNode badEnding;

	public int queensHappiness;

	private void Awake()
	{
		queensHappiness = 0;
	}

	public void ChangeHappiness(int amount) 
	{ 
		queensHappiness += amount; 
	}

	public void GetEnding()
	{
		DialogueNode nodeToUse;
		if (queensHappiness == 3) { nodeToUse = goodEnding; }
		else if (queensHappiness == -3) { nodeToUse = badEnding; }
		else { nodeToUse = midEnding; }

		DialogueManager.Instance.StartDialogue(nodeToUse);
	}
}
