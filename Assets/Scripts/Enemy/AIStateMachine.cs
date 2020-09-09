using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
    // STATE MACHINE
    public enum States 
    {
        IDLE,
        MOVEMENT,
        ATTACK,
        DEATH
    }
    
    public States current_state;
    public int detectionLayerMask = 0;
    
    // MOVEMENT

    public float maxMovementSpeed;
    private float _currentMovementSpeed;
    private Vector3 _currentMovementVector;

    // DETECTION

    public bool isObjectDetected = false;
    public GameObject currentObjectDetected = null;
    public float detectionRayCastLength = 10f;

    private void Awake()
    {
        current_state = States.IDLE;
    }

    private void FixedUpdate()
    {
        StateManager();
    }

    private void StateManager()
    {
        switch (current_state)
        {
            case States.IDLE:
                //Detect Environment
                EnvironmentDetection();
                break;
            case States.MOVEMENT:
                //Move random add timer that counts down until Idle
                break;
            case States.ATTACK:
                //Move towards player add timer that counts down until Idle
                break;
            case States.DEATH:
                // Do FX stuff maybe?
                break;
        }
    }

    private void EnvironmentDetection()
    {
        RaycastHit hit;
        Vector3 currentDirection = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, currentDirection,Color.red, detectionRayCastLength);
        if (Physics.Raycast(transform.position, currentDirection,out hit, detectionRayCastLength, detectionLayerMask))
        {
            currentObjectDetected = hit.collider.gameObject;
            current_state = States.MOVEMENT;
            Debug.Log("Ray has been hit");
        }
    }
}
