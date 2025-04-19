using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	[SerializeField] DialogueNode dialogue;

	void StartDialogue()
	{
		DialogueManager.Instance.StartDialogue(dialogue);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			StartDialogue();
			Destroy(this.gameObject);
		}
	}
}
