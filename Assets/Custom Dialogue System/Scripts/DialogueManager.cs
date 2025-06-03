using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

	[SerializeField] public GameObject interactUI;

	[SerializeField] UnityEvent onDialogueStart;
	[SerializeField] UnityEvent onDialogueEnd;

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

		onDialogueStart.Invoke();

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

		switch (currentNode.type)
        {
			case DialogueNodeType.TEXT:
				display.BeginDisplayText((DialogueTextNode)next);
				break;
			case DialogueNodeType.SELECTION:
				StartSelection((DialogueSelectionNode)next);
				break;
			case DialogueNodeType.CONDITIONAL_SELECTION:
				StartSelection((DialogueConditionalSelectionNode)next);
				break;
			case DialogueNodeType.BIFURCATION_EVENT:
				((DialogueEventBifurcationNode)currentNode).nodeEvent.Invoke();
				break;
			case DialogueNodeType.EVENT:
				((DialogueEventNode)currentNode).nodeEvent.Invoke();
				ChangeNode(((DialogueEventNode)currentNode).Next);
				break;
			default:
				Debug.Log("currentNode of unknown type");
				break;
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

	void StartSelection(DialogueConditionalSelectionNode selectionNode)
	{
		int i = 0;
		foreach (DialogueConditionalSelectionNode.ConditionalSelection conditionalSelection in selectionNode.Selections)
		{
			if (!InformationCollectedManager.Instance.IsInfoUnlocked(conditionalSelection.condition)) { continue; }

			DialogueSelectionNode.Selection selection = conditionalSelection.selection;
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
		onDialogueEnd.Invoke();
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
