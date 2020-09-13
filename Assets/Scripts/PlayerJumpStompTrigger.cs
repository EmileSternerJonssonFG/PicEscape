using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpStompTrigger : MonoBehaviour
{
    public int damageToDo = 1;
    public string tagToCheck;

    public Rigidbody thisRB;
    public BoxCollider thisBC;
    public float yVelocityToActivateStompTrigger = -0.1f;

    public float bounceForceAmount = 15f;

    private void Awake()
    {
        thisRB = GetComponentInParent<Rigidbody>();
        thisBC = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        Debug.Log(thisRB.velocity.y);
        if(thisRB.velocity.y < yVelocityToActivateStompTrigger)
        {
            thisBC.enabled = true;
        }
        else
        {
            thisBC.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagToCheck)
        {
            thisRB.AddForce(new Vector3(0f, bounceForceAmount, 0f), ForceMode.Impulse);
            var thisEnemyHealth = other.gameObject.GetComponent<HealthSystem>();
            thisEnemyHealth.RemoveHealth(damageToDo);
        }
    }
}
