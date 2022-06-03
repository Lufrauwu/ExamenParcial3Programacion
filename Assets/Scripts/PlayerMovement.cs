using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = default;
    [SerializeField] private Animator _animator = default;
    private float _horizontalMove = default;
    [SerializeField] private Rigidbody2D _rb2d = default;
    [SerializeField] private float jumpAmount = 35;
    [SerializeField] private float gravityScale = 10;
    [SerializeField] private float fallingGravityScale = 40;
    [SerializeField] private Transform _feetTransform = default;
    [SerializeField] private float _checkRadius = default;
    [SerializeField] private LayerMask _groundLayer = default;
    [SerializeField] private Animator _playerAnimator = default;
    [SerializeField]private bool _isGrounded = default;
    private bool _facingRight = true;
    private float _horizontal = default;
    private float _vertical = default;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
       _horizontalMove = Input.GetAxisRaw("Horizontal");
       Vector3 currentPosition = transform.position;
       currentPosition.x += _horizontalMove * _playerSpeed * Time.deltaTime;
       transform.position = currentPosition;
       if (_horizontalMove != 0)
       {
           _playerAnimator.SetBool("IsMoving", true);
       }
       else
       {
           _playerAnimator.SetBool("IsMoving", false);
       }
       if (Input.GetKeyDown(KeyCode.Space))
       {
           Jump();
       }

       if (!_isGrounded)
       {
           _playerAnimator.SetBool("IsJumping", true);
       }
       if (_isGrounded)
       {
           _playerAnimator.SetBool("IsJumping", false); 
       }
       _isGrounded = Physics2D.OverlapCircle(_feetTransform.position, _checkRadius, _groundLayer);
       
       if (_horizontalMove < 0 && _facingRight)
       {
           Flip();
       }
       else if (_horizontalMove > 0 && !_facingRight)
       {
           Flip();
       }

       if (Input.GetKeyDown(KeyCode.S))
       {
           _playerSpeed = 0;
           _playerAnimator.SetBool("IsDucking", true); 
       }
       if (Input.GetKeyUp(KeyCode.S))
       {
           _playerSpeed = 7;
           _playerAnimator.SetBool("IsDucking", false); 
       }
    }
    

    private void Jump()
    {
        if (_isGrounded)
        {
            _rb2d.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            if(_rb2d.velocity.y >= 0)
            {
                _rb2d.gravityScale = gravityScale;
            }
            else if (_rb2d.velocity.y < 0)
            {
                _rb2d.gravityScale = fallingGravityScale;
            } 
        }
    }
    
    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
