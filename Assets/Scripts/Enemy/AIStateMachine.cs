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
    
    // MOVEMENT

    public float maxMovementSpeed;
    public bool moveForceAdded = false;
    public float rotateToTargetTime = 2;

    public Vector2 randomMoveTimeRange = new Vector2(1, 10);
    public Vector2 randomForceMinMaxX = new Vector2(-20, 20);
    public Vector2 randomForceMinMaxY = new Vector2(50, 100);

    private float _currentMovementSpeed;
    private Vector3 _currentDirection;
    private Vector3 _currentTargetPos;

    // DETECTION

    public bool isObjectDetected = false;
    public GameObject currentObjectDetected = null;
    public float detectionRayCastLength = 10f;
    public int detectionLayerMask = 0;

    public Transform[] rayCastTransforms;

    // ThisRigidBody

    private Rigidbody thisRigidBody;

    private void Awake()
    {
        current_state = States.IDLE;
        thisRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        StateManager();

        //****DEBUG****
        if (Input.GetKeyDown(KeyCode.H))
        {
            current_state = States.MOVEMENT;
        }

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
                MoveToward(currentObjectDetected.transform.position, Random.Range(randomMoveTimeRange.x,randomMoveTimeRange.y));
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
        for (int i = 0; i < rayCastTransforms.Length; i++)
        {
            RaycastHit hit;
            Vector3 currentDirection = rayCastTransforms[i].TransformDirection(Vector3.forward);
            Debug.DrawRay(rayCastTransforms[i].position, currentDirection * detectionRayCastLength,Color.red);
            if (Physics.Raycast(rayCastTransforms[i].position, currentDirection * detectionRayCastLength,out hit, detectionRayCastLength, detectionLayerMask))
            {
                Debug.Log("Ray has been hit");
                currentObjectDetected = hit.collider.gameObject;
                current_state = States.MOVEMENT;

                // if look towards target 
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(currentObjectDetected.transform.position), Time.deltaTime * rotateToTargetTime); // OLD STIFF VERSION transform.LookAt(currentObjectDetected.transform.position);
            }
        }
    }

    private void MoveToward(Vector3 targetPosition, float moveTime)
    {
        if(moveForceAdded == false)
        {
            if(targetPosition == null)
            {
                thisRigidBody.AddForce(new Vector3(Random.Range(randomForceMinMaxX.x, randomForceMinMaxX.y), Random.Range(randomForceMinMaxY.x, randomForceMinMaxY.y),1),ForceMode.VelocityChange);
            }
            else
            {
                thisRigidBody.AddRelativeForce(Vector3.forward + targetPosition * maxMovementSpeed, ForceMode.Force);
            }
            StartCoroutine(Countdown(moveTime));
            moveForceAdded = true;
        }
    }

    private IEnumerator Countdown(float moveTime)
    {
       // float duration = 3f; // 3 seconds you can change this 
                             //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f) // In a while loop while counting down
        {
           normalizedTime += Time.deltaTime / moveTime;
           yield return null;
        }
        // Do Stuff Here
        current_state = States.IDLE;
        currentObjectDetected = null;
        moveForceAdded = false;

    }
}
