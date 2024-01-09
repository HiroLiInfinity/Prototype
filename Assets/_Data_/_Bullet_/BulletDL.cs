using UnityEngine;

public class BulletDL : DamageDealer
{
    [SerializeField] protected Dealer dealer;

    public Dealer Dealer => dealer;

    protected Spawner spawner;

    protected override void Start()
    {
        base.Start();
        if(dealer == Dealer.Player) spawner = GameController.Instance.PBulletSpawner;
        if(dealer == Dealer.Monster) spawner = GameController.Instance.MBulletSpawner;
    }

    protected void OnTriggerEnter(Collider collider)
    {
        DealDamageToTarget(Dealer.Player, collider, "Monster");
        DealDamageToTarget(Dealer.Monster, collider, "Player");
        
        if(SkipDealderDR(collider)) return;
        if(collider.gameObject.name == "BulletDL") return;

        DestroyBullet(transform.parent);
    }

    public void SetDealer(Dealer dealer)
    {
        this.dealer = dealer;
    }

    protected void DealDamageToTarget(Dealer dealer, Collider target, string tag)
    {
        if(this.dealer == dealer && target.CompareTag(tag)) DealDamage(target);
    }

    protected bool SkipDealderDR(Collider collider)
    {
        if(dealer == Dealer.Player && collider.CompareTag("Player")) return true;
        if(dealer == Dealer.Monster && collider.CompareTag("Monster")) return true;
        return false;
    }

    protected void DestroyBullet(Transform bullet)
    {
        spawner.Despawn(bullet);
    }
}