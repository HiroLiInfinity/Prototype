using UnityEngine;

public class PlayerMoving : PlayerAbstract
{
    [Header("Moving")]
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float onMoving;
    [SerializeField] protected bool isRight = true;

    protected Rigidbody rb;

    protected override void Start()
    {
        base.Start();
        rb = player.Rigidbody;
    }

    protected void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        onMoving = InputManager.Instance.OnMoving;

        if(onMoving == 0)
        {
            Idle();
            return;
        }

        Walk();
        SetDirection();
        SetModelDirection();
        rb.velocity = new Vector3(onMoving * speed, rb.velocity.y);
    }

    protected void Idle()
    {
        player.Animator.SetInteger("action", 0);
    }

    protected void Walk()
    {
        player.Animator.SetInteger("action", 1);
    }

    protected void SetDirection()
    {
        float onMoving = InputManager.Instance.OnMoving;

        if(onMoving < 0) isRight = false;
        else isRight = true;
    }

    protected void SetModelDirection()
    {
        float x = player.AttackPoint.localPosition.x;
        float y = player.AttackPoint.localPosition.y;
        
        if(isRight) 
        {
            player.Model.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            //playerCtrl.AttackPoint.localPosition = new Vector3(x > 0 ? x : -x, y, 0);
        }
        else 
        {
            player.Model.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
            //playerCtrl.AttackPoint.localPosition = new Vector3(x < 0 ? x : -x, y, 0);
        }
    }
}