using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRock : MonoBehaviour
{
    public Vector3 RockSizeScaler;
    private Vector3 GoingLarge;
    private Vector3 ScaleTowards;
    private bool IsScalingup;
    private Vector3 ScaleFrom;
    private Vector3 Normalsize;
    // Start is called before the first frame update

    private void Awake()
    {
        Normalsize = transform.localScale;
    }
    void Update()
    {
        Scale();
        EndPosition();
    }

    // Update is called once per frame
    void Scale()
    {
         transform.localScale = Vector3.Lerp(transform.localScale, ScaleTowards, Time.deltaTime * 1);
        }

       private void EndPosition()
    {
        if (IsScalingup)
        {
            ScaleTowards = RockSizeScaler;
            ScaleFrom = Normalsize;
        }
        else {
            ScaleFrom = RockSizeScaler;
            ScaleTowards = Normalsize;
        }
        Vector3 a = ScaleTowards - this.transform.localScale;
        float adistance = a.sqrMagnitude;
        if (adistance < 0.1)
        {
            IsScalingup = !IsScalingup;
        }
    }
    }
