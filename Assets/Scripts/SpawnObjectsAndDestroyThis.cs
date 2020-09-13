using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsAndDestroyThis : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Quaternion rotationOfObjects;

    public Vector3 objectPositionsOffset; // TO DO Add RandomOffsets when spawning in future if need be

    public bool destroyAfterSpawn = true;
    public bool hideObjectAfterSpawn = false;

    public GameObject[] objectsToHide;

    public void ExecuteDestroyAndSpawn()
    {
        if(objectsToSpawn != null)
        {
            for (int i = 0; i < objectsToSpawn.Length; i++)
            {
                Instantiate(objectsToSpawn[i], transform.position, rotationOfObjects);
                // TO DO Add Offset per objects if want to...
            }
        }
        if (destroyAfterSpawn)
        {
            Debug.Log("DESTROY THIS OBJECT");
            Destroy(gameObject);
        }
        if (hideObjectAfterSpawn && objectsToHide != null)
        {
            for (int i = 0; i < objectsToHide.Length; i++)
            {
                objectsToHide[i].SetActive(false);
            }
        }
    }
}
