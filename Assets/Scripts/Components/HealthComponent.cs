using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    private float healthbarBackgroundWidth;

    private RectTransform healthbar;

    private bool isAlive;
    private bool isDamaged;

    private void Start()
    {
        healthbar = gameObject.GetComponentInChildren<Canvas>()
            .GetComponentsInChildren<Image>()[1]
            .GetComponent<RectTransform>();

        healthbarBackgroundWidth = healthbar.sizeDelta.x;

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
            healthbar.sizeDelta = new Vector2(healthbarWidth, healthbar.sizeDelta.y);

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private float CalculateHealthbarWidth()
    {
        return currentHealth * healthbarBackgroundWidth / maxHealth;
    }

    private void Die()
    {
        Debug.Log("Object died");
        currentHealth = 0;
        isAlive = false;
    }
}