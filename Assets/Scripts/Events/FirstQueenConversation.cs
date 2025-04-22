using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstQueenConversation : MonoBehaviour
{
    public int queensHappiness;

	private void Awake()
	{
		queensHappiness = 0;
	}

	public void ChangeHappiness(int amount) { queensHappiness += amount; }
}
