using UnityEngine;

public abstract class BulletAbstract : Mono
{
    [SerializeField] protected Bullet bullet;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBullet();
    }

    protected void LoadBullet()
    {
        if(bullet != null) return;

        bullet = transform.parent.GetComponent<Bullet>();
    }
}