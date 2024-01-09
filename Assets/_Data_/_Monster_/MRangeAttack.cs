using UnityEngine;

public class MRangeAttack : MonsterAttack
{
    [Header("Range Attack")]
    [SerializeField] protected float attackRange = 15;
    protected Player player;

    protected override void Start()
    {
        base.Start();

        player = GameController.Instance.Player;
    }

    protected override void Update()
    {
        Detect();
        MAttackPointRotate();
        base.Update();
    }

    protected void Detect()
    {
        if(!monster.MonsterMoving.StopMoving && !monster.MonsterMoving.IsChasing) return;

        Vector3 playerPos = To2DVector(player.transform.position);
        Vector3 attackPoint = To2DVector(monster.AttackPoint.position);
        float distance = Vector3.Distance(playerPos, attackPoint);

        if(distance <= attackRange) monster.MonsterMoving.SetChasing(false);
        else monster.MonsterMoving.SetChasing(true);
    }

    protected void MAttackPointRotate()
    {
        Vector3 playerPos = To2DVector(player.transform.position);
        Vector3 direction = playerPos - monster.AttackPoint.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        monster.AttackPoint.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    protected override void MakeAttack()
    {
        if(!monster.MonsterMoving.StopMoving || monster.MonsterMoving.IsChasing) return;

        monster.MonsterShooting.Shoot();
    }

    protected Vector3 To2DVector(Vector3 vector)
    {
        return new Vector3(vector.x, vector.y, 0);
    }
}