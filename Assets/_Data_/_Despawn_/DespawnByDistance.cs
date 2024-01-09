using UnityEngine;

public class DespawnByDistance : Despawn
{
    [Header("Despawn By Distance")]
    [SerializeField] protected float distance = 30f;

    protected override bool CanDespawn()
    {
        Vector3 obj = To2DVecor(transform.parent.position);
        float distanceZeroToObj = Vector3.Distance(obj, Vector3.zero);

        if(distanceZeroToObj >= distance) return true;
        return false;
    }
}