using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    // debug
    [Header("DEBUG TO DELETE")]
    [SerializeField] DialogueNode headNode;
    [SerializeField] List<SelectionButton> buttons;

    public TextMeshProUGUI textComponent;
    public float textSpeed;

    DialogueNode currentNode;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
		StartDialogue(headNode);
	}

    // Update is called once per frame
    void Update()
    {
        if (currentNode.type == DialogueNodeType.TEXT)
        {
			if (Input.GetMouseButtonDown(0))
			{
				if (textComponent.text.Length == ((DialogueTextNode)currentNode).Text.Length)
				{
					StopAllCoroutines();
					ChangeNode(((DialogueTextNode)currentNode).Next);
				}
				else
				{
					StopAllCoroutines();
					textComponent.text = ((DialogueTextNode)currentNode).Text;
				}
			}
		}
	}

    void StartDialogue(DialogueNode start)
    {
        ChangeNode(start);
    }

    void ChangeNode(DialogueNode next)
    {
		if (next == null)
		{
			gameObject.SetActive(false);
            return;
		}

		currentNode = next;
        Debug.Log("Current Node is " + currentNode.name);

		if (next.type == DialogueNodeType.TEXT)
        {
			textComponent.text = string.Empty;
			StartCoroutine(TypeLine());
		}
		else if (next.type == DialogueNodeType.SELECTION)
		{
			StartSelection((DialogueSelectionNode)next);
		}
    }

    IEnumerator TypeLine()
    {
        foreach (char c in ((DialogueTextNode)currentNode).Text.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
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

    public void SelectOption(DialogueNode next)
    {
        ChangeNode(next);
    }
}
