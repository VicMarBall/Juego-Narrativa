using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectionButton : MonoBehaviour
{
    // will probably change it to a manager
    [SerializeField] Dialogue dialogue;

	public TextMeshProUGUI textComponent;

    DialogueNode nextNode;

    public void SetSelection(DialogueSelectionNode.Selection selection)
    {
        textComponent.text = selection.text;
        nextNode = selection.next;
    }

    public void OnClickButton()
    {
        dialogue.SelectOption(nextNode);
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
