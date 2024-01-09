using UnityEngine;

public class Mono : MonoBehaviour
{
    protected virtual void Awake()
    {
        LoadComponents();
    }

    protected virtual void Start()
    {
        //Override
    }

    protected void Reset()
    {
        LoadComponents();
        ResetValue();
    }

    protected virtual void LoadComponents()
    {
        //Override
    }

    protected virtual void ResetValue()
    {
        //Override
    }

    protected virtual void OnEnable()
    {
        //Override
    }

    protected virtual void OnDisable()
    {
        //Override
    }

    public static Vector3 To2DVecor(Vector3 vector) {
        return new Vector3(vector.x, vector.y, 0);
    }
}