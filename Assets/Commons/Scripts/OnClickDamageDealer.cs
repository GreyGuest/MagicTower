using UnityEngine;

public class OnClickDamageDealer : MonoBehaviour
{
    public int damageAmount = 33;

    public HealthComponent healthComponent;

    private void OnMouseDown()
    {
        healthComponent.TakeDamage(damageAmount);
    }
}