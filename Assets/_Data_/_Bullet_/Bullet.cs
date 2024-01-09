using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : Mono
{
    [SerializeField] protected BulletDL bulletDL;

    public BulletDL BulletDL => bulletDL;

    [SerializeField] protected Spawner spawner;

    public Spawner Spawner => spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDL();
        LoadSpawner();
    }

    protected void LoadDL()
    {
        if(bulletDL != null) return;

        bulletDL = transform.GetComponentInChildren<BulletDL>();
    }

    protected void LoadSpawner()
    {
        if(spawner != null) return;

        spawner = transform.parent.parent.GetComponent<Spawner>();
    }
}