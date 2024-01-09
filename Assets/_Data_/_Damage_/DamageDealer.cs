using UnityEngine;

public class DamageDealer : Mono
{
    [SerializeField] protected int damage = 1;

    public void DealDamage(Collider collider)
    {
        DamageReceiver damageReceiver = collider.GetComponentInChildren<DamageReceiver>();
        
        if(damageReceiver == null) return;
        DealDamage(damageReceiver);
    }

    public void DealDamage(DamageReceiver damageReceiver)
    {
        damageReceiver.TakeDamage(damage);
    }
}