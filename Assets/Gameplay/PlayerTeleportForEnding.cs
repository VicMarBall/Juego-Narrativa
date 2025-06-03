using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportForEnding : MonoBehaviour
{
	[SerializeField] Transform positionToTP;

	public void Teleport()
	{
		transform.position = positionToTP.position;
	}
}
