using UnityEngine;

[RequireComponent(typeof(GameEvent))]
public class OnTriggerEvent : MonoBehaviour
{
    public bool isUseTag;
    public string tagToCheck;
    public GameEvent eventOnTrigger;

    private void Awake()
    {
        eventOnTrigger = GetComponent<GameEvent>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isUseTag)
        {
            if(other.tag == tagToCheck)
            {
                eventOnTrigger.RaiseAllEvents();
            }
        }
        else
        {
            eventOnTrigger.RaiseAllEvents();
        }
    }
}
