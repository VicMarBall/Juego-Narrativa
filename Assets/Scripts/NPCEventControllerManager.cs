using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEventControllerManager : MonoBehaviour
{
    [SerializeField] List<NPCEventController> npcEventControllers;

    public void CloneEventIntoHourFrame(GameObject hourFrameObject)
    {
        foreach (var npc in npcEventControllers)
        {
            npc.CloneEventIntoHourFrame(hourFrameObject);
        }
    }
}