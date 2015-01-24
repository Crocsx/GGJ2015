using UnityEngine;
using System.Collections;

public class Camera_controller : MonoBehaviour
{
    public float recenteringTime = 0.15f;
    public Transform _target;
    [Range(0, 1)]
    public float _elevation;

    private Vector3 velocity = Vector3.zero;
    private Transform _transform;
    void Start()
    {
        _transform = transform;
    }
// Update is called once per frame
    void Update ()
    {
        if (_target)
        {
            Vector3 point = camera.WorldToViewportPoint(_target.position);
            Vector3 delta = _target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, _elevation, point.z));
            Vector3 destination = _transform.position + delta;
            _transform.position = Vector3.SmoothDamp(_transform.position, destination, ref velocity, recenteringTime);
        }
    }
	
}
