using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerAnimation))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;

    private PlayerMovement _playerMovement;
    private Rigidbody2D _rb2d;
    private PlayerState _currentState;
    private int _coinsPickedUp;

    public PlayerState GetState() => _currentState;
    public int CoinsPickedUp() => _coinsPickedUp;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _rb2d = GetComponent<Rigidbody2D>();
        transform.position = _startPoint.position;
    }

    private void Update()
    {
        if (_playerMovement.IsGrounded())
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                _currentState = _playerMovement.IsRunning() ? PlayerState.RUNNING : PlayerState.WALKING;
            else
                _currentState = PlayerState.IDLING;
    }

    private void Respawn()
    {
        _currentState = PlayerState.IDLING;
        _rb2d.velocity = Vector2.zero;
        transform.position = _startPoint.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Enemy>())
            Respawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {
            Destroy(collision.gameObject);
            _coinsPickedUp++;
        }

        if (collision.GetComponent<DeathField>())
            Respawn();
    }
}

    public enum PlayerState
    {
        IDLING,
        WALKING,
        RUNNING
    }