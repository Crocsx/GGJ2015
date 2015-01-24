using UnityEngine;
using System.Collections;

public class pEnemy : MonoBehaviour {
    public int _degats;
    public bool _dealGame = true;
    protected Transform _transform;
    protected Transform _target;
	// Use this for initialization
	public void Start () {
        _transform = transform;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
            Effect();
    }
    public virtual void Effect()
    {
        Debug.Log(_dealGame);
        if (_dealGame)
            _target.GetComponent<CharacterRessources>().GetDamage(_degats);
    }

    public void KillMe()
    {
        GameObject.Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
    
    }
}
