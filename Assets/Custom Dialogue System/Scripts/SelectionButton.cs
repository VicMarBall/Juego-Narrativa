using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectionButton : MonoBehaviour
{
	public TextMeshProUGUI textComponent;

    DialogueNode nextNode;

    public void SetSelection(DialogueSelectionNode.Selection selection)
    {
        textComponent.text = selection.text;
        nextNode = selection.next;
    }

    public void OnClickButton()
    {
        DialogueManager.Instance.SelectOption(nextNode);
    }

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
