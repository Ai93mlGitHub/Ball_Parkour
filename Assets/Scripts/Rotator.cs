using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 _speedRotationVector;

    private Quaternion _startRotation;

    private void Awake()
    {
        _startRotation = transform.rotation;
    }

    private void Update()
    {
        transform.Rotate(_speedRotationVector.x, _speedRotationVector.y * Time.deltaTime, _speedRotationVector.z);
    }

    public void ResetRotation()
    {
        transform.rotation = _startRotation;
    }
}
