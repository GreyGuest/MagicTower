using System.Collections.Generic;
using UnityEngine;

public class FireballSpellEffect : MonoBehaviour
{
    public float damage = 50f;

    [Header("Explosion")] 
    public float explosionDamage = 10f;
    public float explosionRadius = 3f;

    private readonly List<int> damagedGameObjectList = new List<int>();
    private readonly Color explosionRadiusGizmoColor = new Color(1f, 0f, 0f, 0.5f);

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

    private void DealDamageToTargetWithCollider(Collider targetCollider, float damageAmount)
    {
        var healthComponent = targetCollider.gameObject
            .GetComponentInParent<Health>();

        if (healthComponent != null && !damagedGameObjectList.Contains(healthComponent.GetInstanceID()))
        {
            damagedGameObjectList.Add(healthComponent.GetInstanceID());
            healthComponent.TakeDamage(damageAmount);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = explosionRadiusGizmoColor;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}