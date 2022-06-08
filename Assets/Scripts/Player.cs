using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Creature
{
    [SerializeField] private LayerCheck _groundCheck;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpSpeed;

    private Rigidbody2D _rigidbody;

    public bool IsRunning { get; private set; }
    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();
        CheckStates();
        Jump();
        Run();
    }

    private void CheckStates()
    {
        IsGrounded = _groundCheck.IsTouchingGround;
        IsRunning = Direction.x != 0;
    }

    private void Run()
    {
        Direction.x = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(Direction.x * _runSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            _rigidbody.velocity += new Vector2(Direction.x, _jumpSpeed);
        }
    }
}