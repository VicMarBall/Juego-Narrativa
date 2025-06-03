using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartEndingScript : MonoBehaviour
{
	// change timer, hide all events, start final event
	[SerializeField] public UnityEvent startEndingEvents;

	public void StartEnding()
	{
		startEndingEvents.Invoke();
	}
}
