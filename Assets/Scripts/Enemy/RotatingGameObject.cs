using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingGameObject : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public GameObject objectToRotate;

    private void Awake()
    {
        if(objectToRotate == null)
        {
            objectToRotate = GetComponent<GameObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        objectToRotate.transform.Rotate(Vector3.forward, Mathf.Lerp(0,360, rotationSpeed * Time.deltaTime));
        //Mathf.Lerp(objectToRotate.transform.rotation.z, objectToRotate.transform.rotation.z + 360, rotationSpeed);
    }
}
