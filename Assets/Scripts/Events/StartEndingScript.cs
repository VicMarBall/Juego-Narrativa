using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartEndingScript : MonoBehaviour
{
	// change timer, hide all events, start final event
	[SerializeField] public UnityEvent startEndingEvents;

	bool endingTriggered;

	private void Awake()
	{
		endingTriggered = false;
	}

	public void StartEnding()
	{
		if (!endingTriggered)
		{
			endingTriggered = true;
			startEndingEvents.Invoke();
		}
	}
}
