using UnityEngine;

public class PlayerShooting : PlayerAbstract
{
    [Header("Shooting")]
    [SerializeField] protected Transform bulletObj;
    [SerializeField] protected Transform centerPoint;
    protected Bullet bullet;

    protected override void Start()
    {
        base.Start();
        bullet = GameController.Instance.PBulletSpawner.Bullet;
        bullet.BulletDL.SetDealer(Dealer.Player);
    }
    
    public void Shoot()
    {
        Transform newBullet = bullet.Spawner.Spawn(bulletObj, player.AttackPoint.position, centerPoint.rotation);
        newBullet.gameObject.SetActive(true);
    }
}