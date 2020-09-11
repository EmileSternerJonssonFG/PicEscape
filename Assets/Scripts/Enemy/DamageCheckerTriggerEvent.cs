using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameEventListener))]
public class DamageCheckerTriggerEvent : MonoBehaviour
{
    public string tagToCheck;
    public GameEventListener eventListener;

    private void Awake()
    {
        eventListener = GetComponent<GameEventListener>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagToCheck)
        {
            eventListener.RaiseEvent();
        }
    }
}
