using UnityEngine;

public abstract class PlayerAttack : PlayerAbstract
{
    [SerializeField] protected float attackDelay = 1;
    [SerializeField] protected float attackTimer;
    [SerializeField] protected bool canAttack = false;

    protected virtual void Update()
    {
        Attack();
    }

    protected void Attack()
    {
        canAttack = CanAttack();

        if(!canAttack) return;

        if(InputManager.Instance.OnAttacking > 0)
        {
            MakeAttack();

            canAttack = false;
            attackTimer = 0;
        }
    }

    protected bool CanAttack()
    {
        if(attackTimer < attackDelay) attackTimer += Time.deltaTime;
        if(attackTimer >= attackDelay) return true;
        return false;
    }

    protected abstract void MakeAttack();
}