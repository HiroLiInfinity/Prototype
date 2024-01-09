using UnityEngine;

public class GameController : Mono
{
    private static GameController instance;

    public static GameController Instance => instance;

    public Cemera Cemera;
    public Player Player;
    public PBulletSpawner PBulletSpawner;
    public MBulletSpawner MBulletSpawner;
    public MonsterSpawner MonsterSpawner;

    protected override void Awake()
    {
        base.Awake();
        if(instance != null) Debug.LogError("Only 1 GameController is allowed to exist!");

        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCemera();
        LoadPlayer();
        LoadPlayerBulletSpawner();
        LoadMonsterBulletSpawner();
        LoadMonsterSpawner();
    }

    protected void LoadCemera()
    {
        if(Cemera != null) return;

        Cemera = FindObjectOfType<Cemera>();
    }

    protected void LoadPlayer()
    {
        if(Player != null) return;

        Player = FindObjectOfType<Player>();
    }

    protected void LoadPlayerBulletSpawner()
    {
        if(PBulletSpawner != null) return;

        PBulletSpawner = FindObjectOfType<PBulletSpawner>();
    }

    protected void LoadMonsterBulletSpawner()
    {
        if(MBulletSpawner != null) return;

        MBulletSpawner = FindObjectOfType<MBulletSpawner>();
    }

    protected void LoadMonsterSpawner()
    {
        if(MonsterSpawner != null) return;

        MonsterSpawner = FindObjectOfType<MonsterSpawner>();
    }
}