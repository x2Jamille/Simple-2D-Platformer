using UnityEngine;

[RequireComponent(typeof(Player),typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _jumpTime;
    [SerializeField] private LayerMask _platformsLayer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;

    private Rigidbody2D _rb2d;
    private bool _isGrounded;
    private float _jumpTimeCounter;
    private bool _isStoppedJumping;
    private bool _isRunning;
    private bool _isLookingToLeft;

    public bool IsRunning() => _isRunning;
    public bool IsGrounded() => _isGrounded;
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _jumpTimeCounter = _jumpTime;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _platformsLayer);
        Jump();
    }

    private void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        _isRunning = Input.GetButton("Fire3");

        Vector3 moveDirection = new Vector3(xAxis, 0, 0);
        if (moveDirection.x < 0 && !_isLookingToLeft || moveDirection.x > 0 && _isLookingToLeft)
            FlipSpriteX();
        transform.position += moveDirection * (_isRunning ? _runSpeed : _walkSpeed) * Time.fixedDeltaTime;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb2d.velocity = Vector2.up * _jumpForce;
            _isStoppedJumping = false;
            _jumpTimeCounter = _jumpTime;
        }
        if (Input.GetButton("Jump") && !_isStoppedJumping)
        {
            if (_jumpTimeCounter > 0)
            {
                _rb2d.velocity = Vector2.up * _jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isStoppedJumping = true;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            _jumpTimeCounter = 0;
            _isStoppedJumping = true;
        }
    }

    private void FlipSpriteX()
    {
        _isLookingToLeft = !_isLookingToLeft;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
