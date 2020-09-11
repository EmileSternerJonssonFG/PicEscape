using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public float MovementSpeed = 2f;
    private Vector3 startpos;
    public Vector3 Direction;
    private Vector3 MovingTowards;
    public float Distance;
    private bool IsForward;
    private Vector3 MovingFrom;

    
    // Start is called before the first frame update
    void Awake()
    {
        startpos = transform.position;
        Direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        EndPosition();
        Move();
    }
    private void Move()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, MovingTowards, MovementSpeed * Time.deltaTime);
    }
    private void EndPosition()
    {
        if (IsForward)
        {
            MovingTowards = startpos + Direction * Distance;
            MovingFrom = startpos;
        }
        else {
            MovingTowards = startpos;
            MovingFrom = startpos + Direction * Distance;
        }
        Vector3 a = MovingTowards - this.transform.position;
        float adistance = a.sqrMagnitude;
        if (adistance < 0.1)
        {
            IsForward = !IsForward;
        }
    }
}
