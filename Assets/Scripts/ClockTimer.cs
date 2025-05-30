using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ClockTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI clockText;
    [SerializeField] float totalTime;
    
    bool timerActivated;

    float elapsedTime;

    bool hasBeen20oClock = false;
	bool hasBeen21oClock = false;
	bool hasBeen22oClock = false;
	bool hasBeen23oClock = false;
	bool hasBeen24oClock = false;

	// events after the first queen conversation
	[SerializeField] UnityEvent on20oClockEvents;
	[SerializeField] UnityEvent on21oClockEvents;
	[SerializeField] UnityEvent on22oClockEvents;
	[SerializeField] UnityEvent on23oClockEvents;
	[SerializeField] UnityEvent on24oClockEvents;

	private void Awake()
	{
		timerActivated = false;
	}

	public void SetTimer(int hour)
    {
        elapsedTime = hour * 60;
    }

	// Update is called once per frame
	void Update()
    {
        if (timerActivated)
        {
            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            clockText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
			//if (elapsedTime <= 0)
			//{
			//    OnTimerFinished();
			//}

			CheckHours();
		}
	}

    void CheckHours()
    {
        if (!hasBeen20oClock)
        {
            if (elapsedTime >= 20 * 60)
            {
                hasBeen20oClock = true;
                on20oClockEvents.Invoke();
            }
        }

		if (!hasBeen21oClock)
		{
			if (elapsedTime >= 21 * 60)
			{
				hasBeen21oClock = true;
				on21oClockEvents.Invoke();
			}
		}

		if (!hasBeen22oClock)
		{
			if (elapsedTime >= 22 * 60)
			{
				hasBeen22oClock = true;
				on22oClockEvents.Invoke();
			}
		}

		if (!hasBeen23oClock)
		{
			if (elapsedTime >= 23 * 60)
			{
				hasBeen23oClock = true;
				on23oClockEvents.Invoke();
			}
		}

		if (!hasBeen24oClock)
		{
			if (elapsedTime >= 24 * 60)
			{
				hasBeen24oClock = true;
				on24oClockEvents.Invoke();
			}
		}
	}

	public void PlayTimer()
    {
        timerActivated = true;
        //timeLeft = totalTime;
    }

    public void StopTimer()
    {
		timerActivated = false;
	}

	public void AdvanceTime(int minutesToAdvance)
	{
		elapsedTime += minutesToAdvance;
	}
}
