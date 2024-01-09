public class MonsterDR : DamageReceiver
{
    protected override void Start()
    {
        base.Start();

        transform.tag = "Monster";
    }

    protected override void DespawnObj()
    {
        base.DespawnObj();
        GameController.Instance.MonsterSpawner.Despawn(transform.parent);
    }
}