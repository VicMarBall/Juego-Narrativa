using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSongScene : MonoBehaviour
{
	[SerializeField] public DialogueNode secretEnding;
	[SerializeField] public DialogueNode goodEnding;
	[SerializeField] public DialogueNode badEnding;

	int queensHappiness;

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
		if (queensHappiness == 0 || queensHappiness == 1) { nodeToUse = badEnding; }
		else if (queensHappiness == 2 || queensHappiness == 3 || queensHappiness == 4) { nodeToUse = goodEnding; }
		else if (queensHappiness >= 5) { nodeToUse = secretEnding; }
        else { nodeToUse = badEnding; }

        DialogueManager.Instance.StartDialogue(nodeToUse);
	}
}
