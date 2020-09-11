using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RayCastDoOnCollisionEvent : MonoBehaviour
{
    // DETECTION

    public bool isObjectDetected = false;
    public GameObject currentObjectDetected = null;
    public float detectionRayCastLength = 10f;
    public int detectionLayerMask = 1;

    // RAYCASTS

    public Transform[] rayCastTransforms;

    // EVENTS

    public UnityEvent eventToDo;

    [Tooltip("Random Delay Between detection, if false, delay = delayBetweenEventMinMax.x")]
    public bool randomDelayBetweenEvent = false;
    public Vector2 delayBetweenEventMinMax = new Vector2(1,2);

    public bool isDelayDone = true;

    void Update()
    {
        if (isDelayDone)
        {
            RayCastDetection();
        }
    }

    private void RayCastDetection()
    {
        for (int i = 0; i < rayCastTransforms.Length; i++)
        {
            RaycastHit hit;
            Vector3 currentDirection = rayCastTransforms[i].TransformDirection(Vector3.forward);
            Debug.DrawRay(rayCastTransforms[i].position, currentDirection * detectionRayCastLength, Color.red);
            if (Physics.Raycast(rayCastTransforms[i].position, currentDirection * detectionRayCastLength, out hit, detectionRayCastLength, detectionLayerMask))
            {
                currentObjectDetected = hit.collider.gameObject;
                eventToDo.Invoke();

            }
        }
        if (randomDelayBetweenEvent)
        {
            StartCoroutine(Countdown(Random.Range(delayBetweenEventMinMax.x,delayBetweenEventMinMax.y)));
        }
        else
        {
            StartCoroutine(Countdown(delayBetweenEventMinMax.x));
        }
    }

    private IEnumerator Countdown(float delayTime)
    {
        isDelayDone = false;
        float normalizedTime = 0;
        while (normalizedTime <= 1f) // In a while loop while counting down
        {
            normalizedTime += Time.deltaTime / delayTime;
            yield return null;
        }
        isDelayDone = true;

    }
}
