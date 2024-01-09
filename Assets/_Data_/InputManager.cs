using UnityEngine;

public class InputManager : Mono
{
    private static InputManager instance;

    public static InputManager Instance => instance;

    [SerializeField] protected Vector3 mousePos;

    public Vector3 MousePos => mousePos;

    [SerializeField] protected float onMoving;

    public float OnMoving => onMoving;

    [SerializeField] protected bool onJumping;

    public bool OnJumping => onJumping;

    protected float onAttacking;

    public float OnAttacking => onAttacking;

    protected override void Awake()
    {
        base.Awake();
        if(instance != null) Debug.LogError("Only 1 InputManager is allowed to exist!");

        instance = this;
    }

    protected void Update()
    {
        GetMousePos();
        GetHorizontalInput();
        GetJumpInput();
        GetFire1();
    }

    protected void GetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected void GetHorizontalInput()
    {
        onMoving = Input.GetAxis("Horizontal");
    }

    protected void GetJumpInput()
    {
        onJumping = Input.GetKeyDown(KeyCode.W);
    }

    protected void GetFire1()
    {
        onAttacking = Input.GetAxis("Fire1");
    }
}