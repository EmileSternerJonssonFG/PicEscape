using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/ New Game Event")]
public class GameEvent : ScriptableObject
{
    //Left public so we can see it in the inspector.
    //A better practice would be to leave Listeners private.
    public List<GameEventListener> Listeners;

    public void RaiseAllEvents()
    {
        //Going through listeners backwards so we don't miss any listeners
        //if their event removes themselves from the list.
        for (int i = Listeners.Count - 1; i > -1; i--)
        {
            Listeners[i].RaiseEvent();
        }
    }

    public void Listen(GameEventListener listener)
    {
        if (Listeners.Contains(listener) == false)
        {
            Listeners.Add(listener);
        }
    }

    public void StopListening(GameEventListener listener)
    {
        if (Listeners.Contains(listener) == true)
        {
            Listeners.Remove(listener);
        }
    }
}
