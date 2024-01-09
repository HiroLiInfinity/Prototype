using UnityEngine;

public class PRangeAttack : PlayerAttack
{
    [Header("Range Attack")]
    [SerializeField] protected Transform centerPoint;
    [SerializeField] protected float radius;


    protected override void Start()
    {
        base.Start();
        radius = Vector3.Distance(centerPoint.position, player.AttackPoint.position);
    }

    protected override void Update()
    {
        AttackPointRotate();
        base.Update();
    }

    protected void AttackPointRotate()
    {
        Vector3 mousePos = InputManager.Instance.MousePos;
        Vector3 trueMousePos = new Vector3(mousePos.x, mousePos.y, 0);
        Vector3 direction = trueMousePos - centerPoint.position;
        Vector3 closestPoint = centerPoint.position + direction.normalized * radius;
        player.AttackPoint.position = closestPoint;

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        centerPoint.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    protected override void MakeAttack()
    {
        Slash();
        player.PlayerShooting.Shoot();
    }

    protected void Slash()
    {
        player.Animator.SetTrigger("attack");
    }
}