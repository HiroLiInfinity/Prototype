using Unity.VisualScripting;
using UnityEngine;

public class PMeleeAttack : PlayerAttack
{
    [Header("Melee Attack")]
    [SerializeField] protected float attackRange = 0.5f;
    public LayerMask monsterLayer;

    protected override void MakeAttack()
    {
        Slash();
        DealDamage();
    }

    protected void DealDamage()
    {
        Collider[] monsters = Physics.OverlapSphere(player.AttackPoint.position, attackRange, monsterLayer);
        
        foreach(Collider monster in monsters)
        {
            player.PlayerDL.DealDamage(monster);
        }
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(player.AttackPoint.position, attackRange);
    }

    protected void Slash()
    {
        player.Animator.SetTrigger("attack");
    }
}