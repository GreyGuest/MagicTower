using UnityEngine;

public class OnClickDamageDealer : MonoBehaviour
{
    public int DamageAmount = 33;

    private HealthComponent _healthComponent;

    private void Start()
    {
        _healthComponent = GetComponent<HealthComponent>();
    }

    private void OnMouseDown()
    {
        _healthComponent.TakeDamage(DamageAmount);
    }
}