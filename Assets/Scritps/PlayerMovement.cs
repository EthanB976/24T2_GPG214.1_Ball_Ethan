using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;

    [Header("layer Mask")]
    [SerializeField] private LayerMask _groundLayer;

    [Header("Movement Variables")]
    [SerializeField] private float _movementAcceleration;
    [SerializeField] private float _maxMoveSpeed;
    [SerializeField] private float _linearDrag;
    private float _horizontalDirection;
    private bool _changingDirection => (rb.velocity.x > 0f && _horizontalDirection < 0f) || (rb.velocity.x < 0f && _horizontalDirection > 0f);

    [Header("Jump Variables")]
    [SerializeField] private float _jumpForce = 12f;
    [SerializeField] private float _airLinearDrag = 2.5f;
    [SerializeField] private float _fallMultiplier = 8f;
    [SerializeField] private float _lowJumpFallMultiplier = 5f;
    [SerializeField] private int _extraJumps = 1;
    private int _extraJumpsValue;
    private bool _canJump => Input.GetButtonDown("Jump") && (_onGround || _extraJumpsValue > 0);

    [Header("Ground Collision Variables")]
    [SerializeField] private float _groundRayCastLength;
    private bool _onGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _horizontalDirection = GetInput().x;
        if (_onGround)
        {
            _extraJumpsValue = _extraJumps;
            ApplyLinearDrag();
        }
        else
        {
            ApplyAirLinearDrag();
            FallMultiplier();
        }
        if (_canJump)
        {
            Jump();
            Debug.Log("Jumped");
        }
    }


    private void FixedUpdate()
    {
        CheckCollisions();
        MoveCharacter();
        ApplyLinearDrag();
        
    }

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void MoveCharacter()
    {
        rb.AddForce(new Vector2(_horizontalDirection, 0f) * _movementAcceleration);

        if (Mathf.Abs(rb.velocity.x) > _maxMoveSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * _maxMoveSpeed, rb.velocity.y);
        }
    }

    private void ApplyLinearDrag()
    {
        if (Mathf.Abs(_horizontalDirection) < 0.4f || _changingDirection)
        {
            rb.drag = _linearDrag;
        }
        else
        {
            rb.drag = 0f;
        }
    }

    private void ApplyAirLinearDrag()
    {
        
        rb.drag = _airLinearDrag;
        
    }

    private void Jump()
    {
        if (!_onGround)
        {
            _extraJumpsValue--;
        }

        ApplyAirLinearDrag();

        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void FallMultiplier()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = _fallMultiplier;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = _lowJumpFallMultiplier;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void CheckCollisions()
    {
        _onGround = Physics2D.Raycast(transform.position * _groundRayCastLength, Vector2.down, _groundRayCastLength, _groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _groundRayCastLength);
    }
}
