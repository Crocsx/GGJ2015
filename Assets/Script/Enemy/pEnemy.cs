using UnityEngine;
using System.Collections;

public class pEnemy : MonoBehaviour {
    public int _degats;
    protected Transform _transform;
    protected Transform _target;
	// Use this for initialization
	public void Start () {
        _transform = transform;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
            Effect();
    }

    public virtual void Effect()
    {
        _target.GetComponent<CharacterRessources>().GetDamage(_degats);
    }

	// Update is called once per frame
	void Update () {
    
    }
}
