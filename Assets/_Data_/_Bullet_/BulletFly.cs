using UnityEngine;

public class BulletFly : BulletAbstract
{
    [Header("Bullet Flying")]
    [SerializeField] protected float speed = 5f;

    protected void Update()
    {
        Fly();
    }

    protected void Fly()
    {
        transform.parent.Translate(Vector3.right * speed * Time.deltaTime);
    }
}