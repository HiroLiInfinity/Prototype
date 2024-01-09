using UnityEngine;

public abstract class MonsterAbstract : Mono
{
    [SerializeField] protected Monster monster;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMonster();
    }

    protected void LoadMonster()
    {
        if(monster != null) return;

        monster = transform.parent.GetComponent<Monster>();
    }
}