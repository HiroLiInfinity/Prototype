using UnityEngine;

public abstract class MonsterAttack : MonsterAbstract
{
    [SerializeField] protected float attackTimer;
    [SerializeField] protected float attackDelay = 1f;
    [SerializeField] protected bool canAttack = false;

    protected virtual void Update()
    {
        Attack();
    }

    protected void Attack()
    {
        canAttack = CanAttack();

        if(!canAttack) return;

        MakeAttack();

        canAttack = false;
        attackTimer = 0;
    }

    protected bool CanAttack()
    {
        if(attackTimer < attackDelay) attackTimer += Time.deltaTime;
        if(attackTimer >= attackDelay) return true;
        return false;
    }

    protected abstract void MakeAttack();
}