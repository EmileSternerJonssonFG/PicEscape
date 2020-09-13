using UnityEngine;
using System.Collections;
using UnityEditor.Events;

[RequireComponent(typeof(SimpleEventExecutor))]
public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 1;
    public int currentHealth = 1;

    public SimpleEventExecutor onDeathEvent;

    public bool hasKnockBack = true;
    public KnockBack knockBack;

    public GameObject fxToSpawnOnHit;

    public bool destroyOnDeath = false;


    private void Awake()
    {
        if (hasKnockBack)
        {
            knockBack = GetComponent<KnockBack>();
        }
    }

    public void RemoveHealth(int healthToRemove = 1)
    {
        currentHealth -= healthToRemove;

        if(fxToSpawnOnHit != null)
        {
            Instantiate(fxToSpawnOnHit,transform.position,transform.rotation);
        }

        if (hasKnockBack)
        {
            knockBack.Knockback();
        }
        CheckHealth();
        Debug.Log("RemoveHealth -=" + healthToRemove);
    }

    public void RecieveHealth(int healthToRecieve = 1)
    {
        currentHealth += healthToRecieve;
    }

    public void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            onDeathEvent.ExecuteEvent();
            Debug.Log("onDeathEvent!");
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
            currentHealth = 0;
        Debug.Log("CurrentHealth is" + currentHealth);
        } // Add if isUseDelay flag if want to in future
    }
}