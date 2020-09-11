using UnityEngine;
using UnityEditor.Events;

[RequireComponent(typeof(GameEventListener))]
public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    public GameEvent onDeathEvent;

    public void RemoveHealth(int healthToRemove = 1)
    {
        currentHealth -= healthToRemove;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        CheckHealth();
    }

    public void RecieveHealth(int healthToRecieve = 1)
    {
        currentHealth += healthToRecieve;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void CheckHealth()
    {
        if(currentHealth <= 0)
        {
            onDeathEvent.RaiseAllEvents();
        }
    }
}
