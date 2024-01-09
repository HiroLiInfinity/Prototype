using UnityEngine;

public class DamageReceiver : Mono
{
    [SerializeField] protected int currentHP = 10;
    [SerializeField] protected int maxHP = 10;

    protected override void OnEnable()
    {
        base.OnEnable();
        Reborn();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        
        if(!IsDead()) return;
        DespawnObj();
    }

    protected bool IsDead()
    {
        return currentHP <= 0;
    }

    protected void Reborn()
    {
        currentHP = maxHP;
    }

    protected virtual void DespawnObj()
    {
        //Override
    }
}