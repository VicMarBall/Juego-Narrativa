using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	#region SINGLETON
	static DialogueManager instance;
	public static DialogueManager Instance
	{
		get
		{
			if (instance == null)
				instance = FindObjectOfType<DialogueManager>();

			return instance;
		}
	}

	#endregion

	[Header("DEBUG TO DELETE")]
	[SerializeField] DialogueNode headNode;
	[SerializeField] List<SelectionButton> buttons;

	DialogueNode currentNode;

	[SerializeField] Canvas canvas;
	[SerializeField] DialogueDisplay displayPrefab;
	DialogueDisplay display;

	// DEBUG TO DELETE
	private void Start()
	{
		StartDialogue(headNode);
	}

	// Update is called once per frame
	void Update()
	{
		if (currentNode == null) { return; }

		if (currentNode.type == DialogueNodeType.TEXT)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (display.textComponent.text.Length != ((DialogueTextNode)currentNode).Text.Length)
				{
					display.CompleteTypeLine();
				}
				else
				{
					display.StopAllCoroutines();
					ChangeNode(((DialogueTextNode)currentNode).Next);
				}
			}
		}
	}

	void StartDialogue(DialogueNode start)
	{
		// instantiate the dialogue display
		if (display == null)
		{
			display = Instantiate(displayPrefab, canvas.transform);
		}

		ChangeNode(start);
	}

	void ChangeNode(DialogueNode next)
	{
		if (next == null)
		{
			EndDialogue();
			return;
		}

		currentNode = next;
		Debug.Log("Current Node is " + currentNode.name);

		if (next.type == DialogueNodeType.TEXT)
		{
			display.BeginDisplayText((DialogueTextNode)next);
		}
		else if (next.type == DialogueNodeType.SELECTION)
		{
			StartSelection((DialogueSelectionNode)next);
		}
	}

	void StartSelection(DialogueSelectionNode selectionNode)
	{
		int i = 0;
		foreach (DialogueSelectionNode.Selection selection in selectionNode.Selections)
		{
			Debug.Log("Selection: " + selection.text);
			buttons[i].SetSelection(selection);
			i++;
		}
	}

	void EndDialogue()
	{
		currentNode = null;
		Destroy(display.gameObject);
	}

	public void SelectOption(DialogueNode next)
	{
		ChangeNode(next);
	}
}
