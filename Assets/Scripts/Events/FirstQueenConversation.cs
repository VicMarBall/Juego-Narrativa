using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstQueenConversation : MonoBehaviour
{
	[SerializeField] public TextMeshProUGUI debugText;

	[SerializeField] public DialogueNode goodEnding;
	[SerializeField] public DialogueNode midEnding;
	[SerializeField] public DialogueNode badEnding;

	public int queensHappiness;

	private void Awake()
	{
		queensHappiness = 0;
		debugText.text = queensHappiness.ToString();
	}

	public void ChangeHappiness(int amount) 
	{ 
		queensHappiness += amount; 
		debugText.text = queensHappiness.ToString(); 
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
