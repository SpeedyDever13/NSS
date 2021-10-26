using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float Speed = 3f;

    [SerializeField] private float _airMultyplier = 0.4f;
    private Animator _animator;
    private MovementControls _controls;
    private float _movementMultyplier = 10f;
    private Vector3 _force;

    private void Awake() 
    {
        _controls = GetComponent<MovementControls>();
        _animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        _controls.Input.KeyboardInput();
        _controls.LookControl();
        _animator.SetBool("Moving", IsMoving());
    }

    private void FixedUpdate() 
    {
        if(!_controls.IsGrounded)
        {
            Move();
        }
    }

    private void Move()
    {
        _force = _controls.Input.MoveDirection.normalized * Speed * _movementMultyplier;
        if(!_controls.IsGrounded)
        {
            _force *= _airMultyplier;
        }
        _controls.Rigidbody.AddForce(_force, ForceMode.Acceleration);
    }

    private bool IsMoving()
    {
        return _controls.Input.HorizontalLook != 0 || _controls.Input.VerticalLook != 0;
    }
}