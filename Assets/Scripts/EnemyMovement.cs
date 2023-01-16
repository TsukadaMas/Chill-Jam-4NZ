using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    enum PatrolAxis {
        VERTICAL,
        HORIZONTAL
    }

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private PatrolAxis _patrolAxis;
    [SerializeField] private bool _startFlipped;

    private float _moveScalar = 1;
    private Vector2 _moveVector;
    

    void Start() {
        if (_startFlipped)
            _moveScalar = -1;

        SetMove(_moveScalar);
    }

    void FixedUpdate()
    {
        var move = _moveVector * _moveSpeed;

        _rb.MovePosition(_rb.position + move * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") {
            _moveScalar *= -1;
            SetMove(_moveScalar);
        }
    }

    private Vector2 SetMove(float moveScalar) {

        switch (_patrolAxis) {
            case PatrolAxis.VERTICAL:
                return _moveVector = new Vector2(0, moveScalar);
            case PatrolAxis.HORIZONTAL:
            default:
                return _moveVector = new Vector2(moveScalar, 0);
        }

    }
}
