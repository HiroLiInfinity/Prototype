using UnityEngine;

public class MonsterShooting : MonsterAbstract
{
    [Header("Shooting")]
    [SerializeField] protected Transform bulletObj;
    [SerializeField] protected Transform attackPoint;
    protected Bullet bullet;

    protected override void Start()
    {
        base.Start();
        bullet = GameController.Instance.MBulletSpawner.Bullet;
        bullet.BulletDL.SetDealer(Dealer.Monster);
    }

    public void Shoot()
    {
        Transform newBullet = bullet.Spawner.Spawn(bulletObj, attackPoint.position, attackPoint.rotation);
        newBullet.gameObject.SetActive(true);
    }
}