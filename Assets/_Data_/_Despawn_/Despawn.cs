public abstract class Despawn : Mono
{
    protected void FixedUpdate()
    {
        DespawnObject();
    }

    protected void DespawnObject()
    {
        if(!CanDespawn()) return;
        Despawning();
    }

    protected virtual void Despawning()
    {
        //Override
    }

    protected abstract bool CanDespawn();
}