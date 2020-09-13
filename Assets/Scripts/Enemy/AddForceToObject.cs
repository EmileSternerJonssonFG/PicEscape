using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceToObject : MonoBehaviour
{
    [Tooltip("Use Random Force, if not, Vector2.x will be used")]
    public bool isRandom = true;
    public Vector2 randomForceMinMaxX;
    public Vector2 randomForceMinMaxY;
    public Vector2 randomForceMinMaxZ;

    [Tooltip("Offset force to a vector3 from position of object")]
    public bool useOffset = true;
    public Vector3 forceOffset;

    public ForceMode forceMode;

    public Rigidbody rigidBodyToAddForce;

    public bool randomRotation = true;
    public float rotationSpeed = 1f;


    public void OnEnable()
    {
        ApplyForceOnObject(randomForceMinMaxX.x, randomForceMinMaxY.x, randomForceMinMaxZ.x, forceMode, isRandom, useOffset);
        if (randomRotation)
        {
            rigidBodyToAddForce.AddTorque(new Vector3(0, rotationSpeed));
            //rigidBodyToAddForce.transform.Rotate(Vector3.forward, Mathf.Lerp(Random.Range(0, 360), Random.Range(0, 360), rotationSpeed * Time.deltaTime));
            //rigidBodyToAddForce.rotation = rigidBodyToAddForce.rotation.eulerAngles.y(Random.Range(0, 360));
        }
        this.enabled = false;
        
    }

    public void ApplyForceOnObject(float X, float Y, float Z, ForceMode forceMode, bool isRandom = true, bool useOffset = false)
    {
        Debug.Log("ApplyForceEventOnObject");
        if (useOffset)
        {
            if (isRandom)
            {
                rigidBodyToAddForce.AddForceAtPosition(new Vector3(Random.Range(randomForceMinMaxX.x, randomForceMinMaxX.y),
                                                            Random.Range(randomForceMinMaxY.x, randomForceMinMaxY.y),
                                                            Random.Range(randomForceMinMaxZ.x, randomForceMinMaxZ.y)),
                                                            rigidBodyToAddForce.position + forceOffset, forceMode);
            }
            else
            {
                rigidBodyToAddForce.AddForceAtPosition(new Vector3(randomForceMinMaxX.x, randomForceMinMaxY.x, randomForceMinMaxZ.x),
                                                            rigidBodyToAddForce.position + forceOffset, forceMode);
            }
        }
        else
        {
            if (isRandom)
            {
                rigidBodyToAddForce.AddForce(new Vector3(Random.Range(randomForceMinMaxX.x, randomForceMinMaxX.y),
                                                            Random.Range(randomForceMinMaxY.x, randomForceMinMaxY.y),
                                                            Random.Range(randomForceMinMaxZ.x, randomForceMinMaxZ.y)), forceMode);
            }
            else
            {
                rigidBodyToAddForce.AddForce(new Vector3(randomForceMinMaxX.x, randomForceMinMaxY.x, randomForceMinMaxZ.x),forceMode);
            }
        }
    }
}
