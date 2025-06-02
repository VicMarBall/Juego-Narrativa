using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum InformationOrigin
{
	ALWAYS_TRUE,
	NAYA,
	PUCK_A,
	PUCK_B,
	CALICO,
	DANDELIA,
	SAET,
	MAX_NUMBER // only used to create the dictionary
}

public class InformationCollectedManager : MonoBehaviour
{
	#region SINGLETON
	static InformationCollectedManager instance;
	public static InformationCollectedManager Instance
	{
		get
		{
			if (instance == null)
				instance = FindObjectOfType<InformationCollectedManager>();

			return instance;
		}
	}

	#endregion

	Dictionary<InformationOrigin, bool> infosCollected = new Dictionary<InformationOrigin, bool>();

	private void Awake()
	{
		for (int i = 0; i < (int)InformationOrigin.MAX_NUMBER; ++i)
		{
			infosCollected.Add((InformationOrigin)i, false);
		}

		infosCollected[InformationOrigin.ALWAYS_TRUE] = true;
	}

	public void UnlockInformation(int origin)
	{
		infosCollected[(InformationOrigin)origin] = true;
	}

	public bool IsInfoUnlocked(InformationOrigin origin)
	{
		return infosCollected[origin];
	}
}
