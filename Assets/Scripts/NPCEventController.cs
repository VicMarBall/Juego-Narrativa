using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEventController : MonoBehaviour
{
    int phase = 0;

    [SerializeField] List<GameObject> eventLayoutPerPhase;

    public void CloneEventIntoHourFrame(GameObject hourFrameObject)
    {
        if (eventLayoutPerPhase[phase] != null)
        {
			Instantiate(eventLayoutPerPhase[phase], hourFrameObject.transform);
		}
	}

    public void NextPhase() { phase++; }
}
