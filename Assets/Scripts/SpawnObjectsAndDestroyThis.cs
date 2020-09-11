using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsAndDestroyThis : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Quaternion rotationOfObjects;

    public Vector3 objectPositionsOffset; // TO DO Add RandomOffsets when spawning in future if need be

    public void ExecuteDestroyAndSpawn()
    {
        for (int i = 0; i < objectsToSpawn.Length; i++)
        {
            Instantiate(objectsToSpawn[i], transform.position, rotationOfObjects);
            // TO DO Add Offset per objects if want to...
        }
        Destroy(gameObject);
    }
}
