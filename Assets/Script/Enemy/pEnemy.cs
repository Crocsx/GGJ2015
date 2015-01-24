using UnityEngine;
using System.Collections;

public class pEnemy : MonoBehaviour {

    protected Transform _transform;
	// Use this for initialization
	public void Start () {
        _transform = transform;
	}

    public virtual void Effect() { }

	// Update is called once per frame
	void Update () {
    
    }
}
