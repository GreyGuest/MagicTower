using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public RectTransform healthBar;

    private bool isAlive;
    private bool isDamaged;

    private void Start()
    {
        isAlive = true;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (isDamaged)
        {
            Debug.Log("Damage handled");

            isDamaged = false;
        }
    }

    public void TakeDamage(int amount)
    {
        if (isAlive)
        {
            Debug.Log("Damage taken");

            isDamaged = true;
            currentHealth -= amount;

            float healthbarWidth = CalculateHealthbarWidth();
            healthBar.sizeDelta = new Vector2(healthbarWidth, healthBar.sizeDelta.y);

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private float CalculateHealthbarWidth()
    {
        return currentHealth * healthBar.sizeDelta.x / maxHealth;
    }

    private void Die()
    {
        Debug.Log("Object died");

        isAlive = false;
    }
}