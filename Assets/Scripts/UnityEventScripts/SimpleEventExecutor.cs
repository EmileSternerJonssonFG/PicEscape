using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleEventExecutor : MonoBehaviour
{
    public bool isExecuteOnStart = false;

    public bool isExecuteDelay = false;
    public float timeToEvent = 1f;
    public UnityEvent eventToHappen;


    public void Start()
    {
        if (isExecuteOnStart)
        {
            if (isExecuteDelay)
            {
                ExecuteEventWithDelay(timeToEvent);
            }
            else
            {
                ExecuteEvent();
            }
        }
    }

    public IEnumerator Countdown(float timeToEvent)
    {
        float normalizedTime = 0;
        while (normalizedTime <= 1f) // In a while loop while counting down
        {


            normalizedTime += Time.deltaTime / timeToEvent;
            yield return null;
        }
        ExecuteEvent();
    }

    public void ExecuteEvent()
    {
        eventToHappen.Invoke();
    }

    public void ExecuteEventWithDelay(float timeToEvent)
    {
        StartCoroutine(Countdown(timeToEvent));
    }

    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
