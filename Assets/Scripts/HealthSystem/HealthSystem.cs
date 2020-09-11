using UnityEngine;
using UnityEditor.Events;

[RequireComponent(typeof(SimpleEventExecutor))]
public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    public SimpleEventExecutor onDeathEvent;


    public void RemoveHealth(int healthToRemove = 1)
    {
        currentHealth -= healthToRemove;
        //currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        CheckHealth();
        Debug.Log("RemoveHealth -=" + healthToRemove);
    }

    public void RecieveHealth(int healthToRecieve = 1)
    {
        currentHealth += healthToRecieve;
        //currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void CheckHealth()
    {
        Debug.Log("CurrentHealth is" + currentHealth);
        if (currentHealth <= 0)
        {
            onDeathEvent.ExecuteEvent();
            Debug.Log("onDeathEvent!");
        } // Add if isUseDelay flag if want to in future
    }
}