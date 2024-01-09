using UnityEngine;

public abstract class PlayerAbstract : Mono
{
    [SerializeField] protected Player player;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
    }

    protected void LoadPlayer()
    {
        if(player != null) return;

        player = transform.parent.GetComponent<Player>();
    }
}