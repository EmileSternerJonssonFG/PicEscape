using UnityEngine;

[RequireComponent(typeof(SimpleEventExecutor))]
public class OnCollisionEvent : MonoBehaviour
{
    public bool isUseTag;
    public string tagToCheck;
    public SimpleEventExecutor eventOnCollision;

    public Collision currentGameObjectCollison;

    private void Awake()
    {
        eventOnCollision = GetComponent<SimpleEventExecutor>();
    }

    
    public void OnCollisionEnter(Collision other)
    {
        if (isUseTag)
        {
            if (other.collider.tag == tagToCheck)
            {
                eventOnCollision.ExecuteEvent();
            }
        }
        else
        {
            eventOnCollision.ExecuteEvent();
        }
        currentGameObjectCollison = other;
    }
}