using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _leftPoint;
    [SerializeField] private Vector2 _rightPoint;

    private bool _isMovingToLeft = true;

    private void Update()
    {
        if (transform.position.x <= _leftPoint.x && _isMovingToLeft)
            TurnAround();
        else if (transform.position.x >= _rightPoint.x && !_isMovingToLeft)
            TurnAround();
    }

    private void FixedUpdate()
    {
        if (_isMovingToLeft)
            transform.Translate(-_speed * Time.fixedDeltaTime, 0, 0);
        else
            transform.Translate(_speed * Time.fixedDeltaTime, 0, 0);
    }

    private void TurnAround()
    {
        _isMovingToLeft = !_isMovingToLeft;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
