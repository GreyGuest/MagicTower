using UnityEngine;

public class OnClickDamageDealer : MonoBehaviour
{
    public float damageAmount = 33;

    private Health healthComponent;

    private void Start()
    {
        healthComponent = GetComponentInParent<Health>();
    }

    private void OnMouseDown()
    {
        healthComponent.TakeDamage(damageAmount);
    }
}