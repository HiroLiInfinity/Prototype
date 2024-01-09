using UnityEngine;

public class MonsterMoving : MonsterAbstract
{
    [Header("Moving")]
    [SerializeField] protected float speed = 1;
    [SerializeField] protected float moveRadius = 5;
    [SerializeField] protected Vector3 minPoint, maxPoint;
    [SerializeField] protected bool stopMoving = false;

    public bool StopMoving => stopMoving;

    [SerializeField] protected bool isRight = true;
    [SerializeField] protected float detectionRange = 8;
    [SerializeField] protected bool isChasing = false;

    public bool IsChasing => isChasing;
    protected Rigidbody rb;
    protected CapsuleCollider capsule;

    protected override void Start()
    {
        base.Start();
        minPoint = transform.parent.position - Vector3.right * 5;
        maxPoint = transform.parent.position + Vector3.right * 5;
        rb = monster.Rigidbody;
        capsule = GameController.Instance.Player.CapsuleCollider;
    }

    protected void Update()
    {
        DectectOp();
        Move();
        Chase();
    }

    protected void DectectOp()
    {
        if((isChasing && stopMoving) || (!isChasing && stopMoving)) return;

        Vector3 player3DPos = GameController.Instance.Player.transform.position;
        Vector3 playerPos = ChangeTo2DPos(player3DPos);
        float distance = Vector3.Distance(playerPos, transform.parent.position);

        if(distance > detectionRange) return;

        stopMoving = true;
        isChasing = true;
    }

    protected void Move()
    {
        if(stopMoving) return;

        ChangeDirectionMove();
        SetModelDirection();
        MakeAMove();
    }

    protected void ChangeDirectionMove()
    {
        if(transform.parent.position.x >= maxPoint.x) isRight = false;
        if(transform.parent.position.x <= minPoint.x) isRight = true;
    }

    protected void SetModelDirection()
    {
        float x = monster.AttackPoint.localPosition.x;
        float y = monster.AttackPoint.localPosition.y;

        if(isRight)
        {
            monster.Model.localScale = new Vector3(1, 1, 1);
            monster.AttackPoint.localPosition = new Vector3(x > 0 ? x : -x, y, 0);
        }
        else
        {
            monster.Model.localScale = new Vector3(-1, 1, 1);
            monster.AttackPoint.localPosition = new Vector3(x < 0 ? x : -x, y, 0);
        }
    }

    protected void MakeAMove()
    {
        if(isRight)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y);
        }
    }

    protected void Chase()
    {
        if(!isChasing) return;

        Vector3 playerPos = GameController.Instance.Player.transform.position;

        ChangeDirectionChase();
        SetModelDirection();

        if(isRight && playerPos.x < monster.AttackPoint.position.x + capsule.radius) return;
        if(!isRight && playerPos.x > monster.AttackPoint.position.x - capsule.radius) return;
        MakeAMove();
    }

    protected void ChangeDirectionChase()
    {
        Vector3 playerPos = GameController.Instance.Player.transform.position;
        if(transform.parent.position.x < playerPos.x) isRight = true;
        if(transform.parent.position.x > playerPos.x) isRight = false;
    }

    protected Vector3 ChangeTo2DPos(Vector3 vector3)
    {
        return new Vector3(vector3.x, vector3.y, 0);
    }

    public void SetChasing(bool isChasing)
    {
        this.isChasing = isChasing;
    }
}