using UnityEngine;

[RequireComponent(typeof(SimpleEventExecutor))]
public class OnTriggerEvent : MonoBehaviour
{
    public bool isUseTag;
    public string tagToCheck;
    public SimpleEventExecutor eventOnTrigger;

    private void Awake()
    {
        eventOnTrigger = GetComponent<SimpleEventExecutor>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isUseTag)
        {
            if (other.tag == tagToCheck)
            {
                eventOnTrigger.ExecuteEvent();
            }
        }
        else
        {
            eventOnTrigger.ExecuteEvent();
        }
    }
}