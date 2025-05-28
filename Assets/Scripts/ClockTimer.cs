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
        }
    }

    public void BeginTimer()
    {
        timerActivated = true;
        //timeLeft = totalTime;
    }
}
