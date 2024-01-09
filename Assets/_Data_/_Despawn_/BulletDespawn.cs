using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    [SerializeField] protected Dealer dealer;
    protected Spawner spawner;

    protected override void Start()
    {
        base.Start();
        dealer = transform.parent.GetComponentInChildren<BulletDL>().Dealer;
        if(dealer == Dealer.Player) spawner = GameController.Instance.PBulletSpawner;
        if(dealer == Dealer.Monster) spawner = GameController.Instance.MBulletSpawner;
    }

    protected override void Despawning()
    {
        base.Despawning();
        spawner.Despawn(transform.parent);
    }
}