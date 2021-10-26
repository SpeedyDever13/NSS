using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public float HorizontalLook;
    [HideInInspector] public float VerticalLook;
    [HideInInspector] public Vector3 MoveDirection;
    [HideInInspector] public Vector3 LookDirection;
    
    private float _verticalMove;
    private float _horizontalMove;

    public void KeyboardInput()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");
        _verticalMove = Input.GetAxisRaw("Vertical");
        MoveDirection = transform.forward * _verticalMove + transform.right * _horizontalMove;

        HorizontalLook = Input.GetAxis("Horizontal");
        VerticalLook = Input.GetAxis("Vertical");
        LookDirection = transform.forward * VerticalLook + transform.right * HorizontalLook;
    }
}