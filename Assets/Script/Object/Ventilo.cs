using UnityEngine;
using System.Collections;

public class Ventilo : MonoBehaviour {
    public float _ascensionSpeed;
    public float _ascensionRange;
    public bool _fanOn = true;
    public LayerMask mask;
    private Transform _transform;
	// Use this for initialization
	void Start ()
    {
        _transform = transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (!_fanOn)
            return;

        RaycastHit2D hit = Physics2D.Raycast(_transform.position, _transform.up, _ascensionRange, mask);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.tag);
            hit.collider.transform.Translate(_transform.up * Time.deltaTime * _ascensionSpeed);
        }
	}
}
