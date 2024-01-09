using System.Globalization;
using UnityEngine;

public class PlayerJumping : PlayerAbstract
{
    [Header("Jumping")]
    [SerializeField] protected float jumpForce = 10;
    [SerializeField] protected float jumpDelay = 2;
    [SerializeField] protected float jumpTimer;
    [SerializeField] protected bool canJump = false;

    protected Rigidbody rb;

    protected override void Start()
    {
        base.Start();
        rb = player.Rigidbody;
    }

    protected void Update()
    {
        Jump();
    }

    protected void Jump()
    {
        canJump = CanJump();

        if(!canJump) return;

        if(InputManager.Instance.OnJumping)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);

            canJump = false;
            jumpTimer = 0;
        }
    }

    protected bool CanJump()
    {
        if(jumpTimer < jumpDelay) jumpTimer += Time.deltaTime;
        if(jumpTimer >= jumpDelay) return true;
        return false;
    }
}