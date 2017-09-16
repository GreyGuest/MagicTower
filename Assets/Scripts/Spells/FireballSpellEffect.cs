using System.Collections.Generic;
using UnityEngine;

public class FireballSpellEffect : MonoBehaviour
{
    public int damage = 50;

    [Header("Explosion")] 
    public int explosionDamage = 10;
    public float explosionRadius = 3;

    private readonly List<int> damagedGameObjectList = new List<int>();

    private void OnCollisionEnter(Collision other)
    {
        DealDamageToTargetWithCollider(other.collider, damage);

        var collisionPosition = gameObject.transform.position;
        var collidersInSphere = Physics.OverlapSphere(collisionPosition, explosionRadius);
        foreach (var targetCollider in collidersInSphere)
        {
            DealDamageToTargetWithCollider(targetCollider, explosionDamage);
        }

        gameObject.SetActive(false);
    }

    private void DealDamageToTargetWithCollider(Collider targetCollider, int damageAmount)
    {
        var healthComponent = targetCollider.gameObject
            .GetComponentInParent<HealthComponent>();

        if (healthComponent != null && !damagedGameObjectList.Contains(healthComponent.GetInstanceID()))
        {
            damagedGameObjectList.Add(healthComponent.GetInstanceID());
            healthComponent.TakeDamage(damageAmount);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}