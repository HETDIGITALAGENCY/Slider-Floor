using UnityEngine;

public class FollowCam : MonoBehaviour
{

    [SerializeField] private Vector3 offset = new Vector3(0f, 5f, -10f);
    private float _smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform _target;

    
    private void LateUpdate()
    {
        camFollow();
    }

    private void camFollow()
    {
        Vector3 _targetPosition = _target.TransformPoint(offset);
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref velocity, _smoothTime);
        transform.LookAt(_target.transform.position);
    }
}

