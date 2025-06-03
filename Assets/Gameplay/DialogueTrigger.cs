using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	[SerializeField] DialogueNode dialogue;

	[SerializeField] bool disableTriggerOnInteract = true;

	private void Awake()
	{
		DialogueManager.Instance.interactUI.SetActive(false);
	}

	void StartDialogue()
	{
		DialogueManager.Instance.StartDialogue(dialogue);
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (!DialogueManager.Instance.currentlyOnDialogue)
			{
				DialogueManager.Instance.interactUI.SetActive(true);

				if (Input.GetKey(KeyCode.F))
				{
					DialogueManager.Instance.interactUI.SetActive(false);
					StartDialogue();
					if (disableTriggerOnInteract)
					{
						gameObject.SetActive(false);
					}
				}
			}

		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			DialogueManager.Instance.interactUI.SetActive(false);
		}
	}

	//private void OnTriggerEnter(Collider other)
	//{
	//	if (other.CompareTag("Player"))
	//	{
	//		StartDialogue();
	//		gameObject.SetActive(false);
	//	}
	//}
}
