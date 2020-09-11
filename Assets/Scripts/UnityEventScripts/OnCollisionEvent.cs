using UnityEngine;

[RequireComponent(typeof(GameEvent))]
public class OnCollisionEvent : MonoBehaviour
{
    public bool isUseTag;
    public string tagToCheck;
    public GameEvent eventOnCollision;

    private void Awake()
    {
        eventOnCollision = GetComponent<GameEvent>();
    }

    public void OnCollisionEnter(Collider other)
    {
        if (isUseTag)
        {
            if (other.tag == tagToCheck)
            {
                eventOnCollision.RaiseAllEvents();
            }
        }
        else
        {
            eventOnCollision.RaiseAllEvents();
        }
    }
}
