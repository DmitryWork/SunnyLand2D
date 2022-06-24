using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Creature
{
    [SerializeField] private LayerCheck _groundCheck;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _knockPower;

    private readonly WaitForSeconds _knockBackDelay = new(0.3f);

    private SpriteRenderer _sprite;
    private Coroutine _coroutine;
    private Rigidbody2D _rigidbody;
    private bool _isKnocked;

    public bool IsRunning { get; private set; }
    public bool IsGrounded { get; private set; }
    public bool IsJumpOnEnemy { get; private set; }

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
        IsRunning = Direction.x != 0;
        IsGrounded = _groundCheck.IsTouchingGround;
        IsJumpOnEnemy = _groundCheck.IsTouchingEnemyHead;
    }

    private void Run()
    {
        if (_isKnocked == false)
        {
            Direction.x = Input.GetAxis("Horizontal");
            _rigidbody.velocity = new Vector2(Direction.x * _runSpeed, _rigidbody.velocity.y);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            _rigidbody.velocity += new Vector2(Direction.x, _jumpSpeed);
        }
    }

    public void KnockBack(Transform target)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Push(target));

    }

    private IEnumerator Push(Transform target)
    {
        _isKnocked = true;
        var direction = transform.position - target.position;
        _rigidbody.velocity = direction.normalized * _knockPower;
        yield return _knockBackDelay;
        _isKnocked = false;

    }
}