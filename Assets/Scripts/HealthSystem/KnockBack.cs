using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KnockBack : MonoBehaviour
{
    public float knockBackForce;
    public float knockBackTime;
    public Vector3 knockBackDirection;

    public Rigidbody thisRigidbody;
    private OnCollisionEvent onCollisionEvent;

    private void Awake()
    {
        onCollisionEvent = GetComponent<OnCollisionEvent>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        onCollisionEvent.currentGameObjectCollison = collision;
    }


    public void Knockback()
    {
        if (onCollisionEvent.currentGameObjectCollison != null)
        {
            knockBackDirection = onCollisionEvent.currentGameObjectCollison.transform.position - transform.position;
            knockBackDirection = knockBackDirection.normalized;
            StartCoroutine(KnockBackCountdown(knockBackTime, knockBackDirection));
        }
    }

    public IEnumerator KnockBackCountdown(float knockBackTime, Vector3 direction)
    {
        thisRigidbody.AddForce(direction * knockBackForce, ForceMode.Impulse);
        float normalizedTime = 0;
        while (normalizedTime <= 1f) // In a while loop while counting down
        {
            normalizedTime += Time.deltaTime / knockBackTime;
            yield return null;
        }

    }
}
