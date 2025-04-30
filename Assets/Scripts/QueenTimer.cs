using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QueenTimer : MonoBehaviour
{
    [SerializeField] float totalTime;
    
    bool timerActivated;

    float timeLeft;

    [SerializeField] UnityEvent onTimerFinishedEvents;

    // Update is called once per frame
    void Update()
    {
        if (timerActivated)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                OnTimerFinished();
            }
        }
    }

    public void BeginTimer()
    {
        timerActivated = true;
        timeLeft = totalTime;
    }

    void OnTimerFinished()
    {
        timerActivated = false;
        onTimerFinishedEvents.Invoke();
    }
}
