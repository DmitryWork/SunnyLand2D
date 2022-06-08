using UnityEngine;

public class Player : Creature
{
    private static readonly int IsRunningKey = Animator.StringToHash("isRunning");
    private static readonly int IsGroundedKey = Animator.StringToHash("isGrounded");
    private static readonly int YVelocity = Animator.StringToHash("yVelocity");

    [SerializeField] private LayerCheck _groundCheck;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpSpeed;
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isGrounded;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        CheckSurroundings();
        SetAnimatorStates();
        Jump();
        Run();
    }

    private void SetAnimatorStates()
    {
        _animator.SetFloat(YVelocity, _rigidbody.velocity.y);
        _animator.SetBool(IsRunningKey, Direction.x != 0);
        _animator.SetBool(IsGroundedKey, _isGrounded);
    }

    private void CheckSurroundings()
    {
        _isGrounded = _groundCheck.IsTouchingGround;
    }

    private void Run()
    {
        Direction.x = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(Direction.x * _runSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody.velocity += new Vector2(Direction.x, _jumpSpeed);
        }
    }
}