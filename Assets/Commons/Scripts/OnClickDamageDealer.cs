using UnityEngine;

public class OnClickDamageDealer : MonoBehaviour
{
    public int damageAmount = 33;

    private HealthComponent healthComponent;

    private void Start()
    {
        healthComponent = GetComponentInParent<HealthComponent>();
    }

    private void OnMouseDown()
    {
        healthComponent.TakeDamage(damageAmount);
    }
}