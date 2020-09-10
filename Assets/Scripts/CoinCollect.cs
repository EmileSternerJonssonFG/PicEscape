using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{

    public float rotationspeed;
    public float collect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0 * Time.deltaTime, rotationspeed);
    }
    }
