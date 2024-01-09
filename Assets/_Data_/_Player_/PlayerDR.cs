public class PlayerDR : DamageReceiver
{
    protected override void Start()
    {
        base.Start();

        transform.tag = "Player";
    }
}