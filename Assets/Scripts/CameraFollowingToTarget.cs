using UnityEngine;

public class CameraFollowingToTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _cameraOffset;

    private void LateUpdate()
    {
        transform.position = _target.position + _cameraOffset;
    }
}
