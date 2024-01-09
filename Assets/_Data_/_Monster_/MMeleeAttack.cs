using UnityEngine;

public class MMeleeAttack : MonsterAttack
{
    [Header("Melee Attack")]
    [SerializeField] protected float attackRange = 1.5f;
    [SerializeField] protected LayerMask playerLayer;

    protected override void MakeAttack()
    {
        DealDamage();
    }

    protected void DealDamage()
    {
        Collider[] players = Physics.OverlapSphere(monster.AttackPoint.position, attackRange, playerLayer);

        foreach(Collider player in players)
        {
            monster.MonsterDL.DealDamage(player);
        }
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(monster.AttackPoint.position, attackRange);
    }
}