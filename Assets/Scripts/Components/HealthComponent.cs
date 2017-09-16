using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public float despawnTime = 1f;

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
        currentHealth = 0;
        isAlive = false;
        Destroy(gameObject, despawnTime);
    }
}