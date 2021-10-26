using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    private void LateUpdate() 
    {
        Vector3 _desiredPosition = _target.position + offset;
        Vector3 _smoothedPosition = Vector3.Lerp(transform.position, _desiredPosition, _smoothSpeed * Time.deltaTime);
        transform.position = _smoothedPosition;
    }
}
