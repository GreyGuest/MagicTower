using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;

    private bool _isAlive;
    private bool _isDamaged;

    private void Start()
    {
        _isAlive = true;
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if (_isDamaged)
        {
            Debug.Log("Damage handled");

            _isDamaged = false;
        }
    }

    public void TakeDamage(int amount)
    {
        if (_isAlive)
        {
            Debug.Log("Damage taken");

            _isDamaged = true;
            CurrentHealth -= amount;

            if (CurrentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Debug.Log("Object died");

        _isAlive = false;
    }
}