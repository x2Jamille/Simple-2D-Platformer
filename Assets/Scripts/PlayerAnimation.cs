using UnityEngine;

[RequireComponent(typeof(Player), typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Player _player;
    private PlayerState _currentState;

    private void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        PlayerState newState = _player.GetState();
        if (_currentState != newState)
        {
            _currentState = newState;

            switch (_currentState)
            {
                case PlayerState.IDLING:
                    _animator.SetBool("IsMoving", false);
                    _animator.SetBool("IsRunning", false);
                    break;
                case PlayerState.WALKING:
                    _animator.SetBool("IsMoving", true);
                    _animator.SetBool("IsRunning", false);
                    break;
                case PlayerState.RUNNING:
                    _animator.SetBool("IsMoving", true);
                    _animator.SetBool("IsRunning", true);
                    break;

            }
        }
    }
}
