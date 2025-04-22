using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectionButton : MonoBehaviour
{
	public TextMeshProUGUI textComponent;

    DialogueSelectionNode.Selection selection;

    public void SetSelection(DialogueSelectionNode.Selection selection)
    {
        textComponent.text = selection.text;
        this.selection = selection;
    }

    public void OnClickButton()
    {
        selection.onSelectEvents.Invoke();
        DialogueManager.Instance.SelectOption(selection.next);
    }
}
