using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float speed;
    public float maxRotation = 45f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.localRotation = Quaternion.Euler(maxRotation * Mathf.Sin(Time.time * speed), 0f , 0f);
       
        
    }

    
}
