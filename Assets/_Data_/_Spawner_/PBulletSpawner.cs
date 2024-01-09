using UnityEngine;

public class PBulletSpawner : Spawner
{
    [Header("Player Bullet Spawner")]
    [SerializeField] protected Bullet bullet;
    
    public Bullet Bullet => bullet;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBullet();
    }

    protected void LoadBullet()
    {
        if(bullet != null) return;

        bullet = transform.Find("Prefabs").Find("Bullet1").GetComponent<Bullet>();
    }
}