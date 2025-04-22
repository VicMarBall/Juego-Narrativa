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

	DialogueNode currentNode;

	[SerializeField] Canvas canvas;
	[SerializeField] DialogueDisplay displayPrefab;
	DialogueDisplay display;

	[SerializeField] GameObject selectionLayout;
	[SerializeField] SelectionButton selectionButtonPrefab;
	List<SelectionButton> selectionButtons = new List<SelectionButton>();

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

	public void StartDialogue(DialogueNode start)
	{
		if (display == null)
		{
			display = Instantiate(displayPrefab, canvas.transform);
		}

		DestroySelectionButtons();

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

		if (currentNode.type == DialogueNodeType.TEXT)
		{
			display.BeginDisplayText((DialogueTextNode)next);
		}
		else if (currentNode.type == DialogueNodeType.SELECTION)
		{
			StartSelection((DialogueSelectionNode)next);
		}
		else if (currentNode.type == DialogueNodeType.BIFURCATION_EVENT)
		{
			((DialogueEventBifurcationNode)currentNode).nodeEvent.Invoke();
		}
	}

	void StartSelection(DialogueSelectionNode selectionNode)
	{
		int i = 0;
		foreach (DialogueSelectionNode.Selection selection in selectionNode.Selections)
		{
			SelectionButton selectionButton = Instantiate(selectionButtonPrefab, selectionLayout.transform);
			Debug.Log("Selection: " + selection.text);
			selectionButton.SetSelection(selection);
			selectionButtons.Add(selectionButton);
			i++;
		}
	}

	void EndDialogue()
	{
		currentNode = null;
		Destroy(display.gameObject);
		DestroySelectionButtons();
	}

	public void SelectOption(DialogueNode next)
	{
		DestroySelectionButtons();

		ChangeNode(next);
	}

	void DestroySelectionButtons()
	{
		foreach (SelectionButton button in selectionButtons)
		{
			Destroy(button.gameObject);
		}

		selectionButtons.Clear();
	}
}
