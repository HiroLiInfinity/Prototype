using UnityEngine;

public class Monster : Mono
{
    [SerializeField] protected Transform model;

    public Transform Model => model;

    [SerializeField] protected Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    [SerializeField] protected Transform attackPoint;

    public Transform AttackPoint => attackPoint;

    [SerializeField] protected MonsterDL monsterDL;

    public MonsterDL MonsterDL => monsterDL;

    [SerializeField] protected MonsterShooting monsterShooting;

    public MonsterShooting MonsterShooting => monsterShooting;

    [SerializeField] protected MonsterMoving monsterMoving;

    public MonsterMoving MonsterMoving => monsterMoving;

    protected override void Start()
    {
        base.Start();
        
        gameObject.layer = LayerMask.NameToLayer("Monster");
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadRigibody();
        LoadAttackPoint();
        LoadDL();
        LoadShooting();
        LoadMoving();
    }

    protected void LoadModel()
    {
        if(model != null) return;

        model = transform.Find("Model");
    }

    protected void LoadRigibody()
    {
        if(_rigidbody != null) return;

        _rigidbody = GetComponent<Rigidbody>();
    }

    protected void LoadAttackPoint()
    {
        if(attackPoint != null) return;

        attackPoint = transform.Find("AttackPoint");
    }

    protected void LoadDL()
    {
        if(monsterDL != null) return;

        monsterDL = GetComponentInChildren<MonsterDL>();
    }

    protected void LoadShooting()
    {
        if(monsterShooting != null) return;

        monsterShooting = GetComponentInChildren<MonsterShooting>();
    }

    protected void LoadMoving()
    {
        if(monsterMoving != null) return;

        monsterMoving = GetComponentInChildren<MonsterMoving>();
    }
}