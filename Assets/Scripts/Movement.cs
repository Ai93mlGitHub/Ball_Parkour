using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _turnTorque = 10f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _dashForce = 10f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckDistance = 0.1f;

    private InputControl _inputControl;
    private Rigidbody _rigidBody;
    private bool _isGrounded;
    private string _groundLayerName = "Ground";
    private Vector3 _startPosition;
    private bool _isRunning = true;

    private void Awake()
    {
        _inputControl = GetComponent<InputControl>();
        _rigidBody = GetComponent<Rigidbody>();
        _groundLayer = LayerMask.NameToLayer(_groundLayerName);
        _startPosition = transform.position;
    }

    void Update()
    {
        Vector3 movementVector = _inputControl.GetMovementVector();
        
        Move(movementVector);

        if (_inputControl.IsJumping() && _isGrounded)
        {
            Jump();
        }

        if (_inputControl.IsDashing() && _isGrounded)
        {
            Dash();
        }

        if (_inputControl.IsReset())
            ResetPosition();
    }
    private void Move(Vector3 direction)
    {
        Vector3 moveForce = direction * _moveSpeed;
        _rigidBody.AddForce(moveForce, ForceMode.Force);
    }

    private void Jump()
    {
        Vector3 jumpForceVector = Vector3.up * _jumpForce;
        _rigidBody.AddForce(jumpForceVector, ForceMode.Impulse);
    }

    private void Dash()
    {
        Vector3 dashForceVector = _rigidBody.velocity.normalized * _dashForce;
        _rigidBody.AddForce(dashForceVector, ForceMode.Impulse);
    }

    public void ResetPosition()
    {
        _rigidBody.velocity = Vector3.zero;
        transform.position = _startPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsGroundLayer(collision))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (IsGroundLayer(collision))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (IsGroundLayer(collision))
        {
            _isGrounded = false;
        }
    }

    private bool IsGroundLayer(Collision collision)
    {
        return collision.gameObject.layer == _groundLayer;
    }

    public void Freeze()
    {
        _rigidBody.isKinematic = true;
    }

    public void UnFreeze()
    {
        _rigidBody.isKinematic = false;
    }
}
