using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent EventToListenFor;
    public UnityEvent EventToBeRaised;

    private void OnEnable()
    {
        EventToListenFor.Listen(this);
    }

    private void OnDisable()
    {
        EventToListenFor.StopListening(this);
    }

    public void RaiseEvent()
    {
        EventToBeRaised.Invoke();
    }
}