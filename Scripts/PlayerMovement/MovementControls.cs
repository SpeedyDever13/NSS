using UnityEngine;

public class MovementControls : MonoBehaviour
{
    [HideInInspector] public Rigidbody Rigidbody;
    [HideInInspector] public PlayerInput Input;
    [HideInInspector] public bool IsGrounded;
    private Transform _gfx;
    

    private void Awake() {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.freezeRotation = true;
        Input = GetComponent<PlayerInput>();
        _gfx = GetComponentInChildren<Eater>().transform;
    }

    private void Update() {
        IsGrounded = Physics.Raycast(_gfx.transform.position, Vector3.down, _gfx.localScale.y/4 + 0.1f);
    }

    public void LookControl()
    {
        _gfx.transform.LookAt(_gfx.transform.position + Input.LookDirection.normalized, _gfx.transform.up);
    }
}