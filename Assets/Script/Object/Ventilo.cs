using UnityEngine;
using System.Collections;

public class Ventilo : MonoBehaviour {
    public float _ascensionSpeed;
    public float _ascensionRange;
    private Transform _transform;
    public LayerMask mask = 9;
	// Use this for initialization
	void Start ()
    {
        _transform = transform;
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(_transform.position, Vector2.up, _ascensionRange, mask);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            hit.collider.transform.Translate(_transform.up * Time.deltaTime * _ascensionSpeed);
        }
	}
}
