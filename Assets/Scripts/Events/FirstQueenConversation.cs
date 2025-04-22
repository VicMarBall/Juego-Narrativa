using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstQueenConversation : MonoBehaviour
{
	[SerializeField] public TextMeshProUGUI debugText;

	public int queensHappiness;

	private void Awake()
	{
		queensHappiness = 0;
		debugText.text = queensHappiness.ToString();
	}

	public void ChangeHappiness(int amount) 
	{ 
		queensHappiness += amount; 
		debugText.text = queensHappiness.ToString(); 
	}
}
