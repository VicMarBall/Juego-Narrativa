using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class DialogueDisplay : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;

	DialogueTextNode currentTextNode;

    void Awake()
    {
        textComponent.text = string.Empty;
	}

	public void BeginDisplayText(DialogueTextNode node)
    {
        StopAllCoroutines();
		textComponent.text = string.Empty;
		currentTextNode = node;
		StartCoroutine(TypeLine());
	}
	
	public void CompleteTypeLine()
	{
		StopAllCoroutines();
		textComponent.text = currentTextNode.Text;
	}

	IEnumerator TypeLine()
    {
        foreach (char c in currentTextNode.Text.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
