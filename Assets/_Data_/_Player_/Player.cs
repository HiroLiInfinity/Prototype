using UnityEngine;

public class Player : Mono
{
    [SerializeField] protected Transform model;

    public Transform Model => model;

    [SerializeField] protected Animator animator;

    public Animator Animator => animator;

    [SerializeField] protected Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    [SerializeField] protected CapsuleCollider capsuleCollider;

    public CapsuleCollider CapsuleCollider => capsuleCollider;

    [SerializeField] protected PlayerMoving playerMoving;

    public PlayerMoving PlayerMoving => playerMoving;

    [SerializeField] protected PlayerDL playerDL;

    public PlayerDL PlayerDL => playerDL;

    [SerializeField] protected Transform attackPoint;

    public Transform AttackPoint => attackPoint;

    [SerializeField] protected PlayerShooting playerShooting;

    public PlayerShooting PlayerShooting => playerShooting;

    protected override void Start()
    {
        base.Start();

        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadAnimator();
        LoadRigidbody();
        LoadCapsuleCollider();
        LoadMoving();
        LoadDL();
        LoadAttackPoint();
        LoadPlayerShooting();
    }

    protected void LoadModel()
    {
        if(model != null) return;

        model = transform.Find("Model");
    }

    protected void LoadAnimator()
    {
        if(animator != null) return;

        animator = transform.Find("Model").transform.GetComponent<Animator>();
    }

    protected void LoadRigidbody()
    {
        if(_rigidbody != null) return;

        _rigidbody = GetComponent<Rigidbody>();
    }

    protected void LoadCapsuleCollider()
    {
        if(capsuleCollider != null) return;

        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    protected void LoadMoving()
    {
        if(playerMoving != null) return;

        playerMoving = transform.GetComponentInChildren<PlayerMoving>();
    }

    protected void LoadDL()
    {
        if(playerDL != null) return;

        playerDL = transform.GetComponentInChildren<PlayerDL>();
    }

    protected void LoadAttackPoint()
    {
        if(attackPoint != null) return;

        attackPoint = transform.Find("AttackPoint");
    }

    protected void LoadPlayerShooting()
    {
        if(playerShooting != null) return;

        playerShooting = GetComponentInChildren<PlayerShooting>();
    }
}