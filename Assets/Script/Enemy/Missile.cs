using UnityEngine;
using System.Collections;

public class Missile : pEnemy {
    public float _speed;

    private float maxCount = 10;
    private Vector3 _direction;
	// Use this for initialization
	void Start () {
        base.Start();
        _direction = _transform.parent.right;
        _transform.eulerAngles = _transform.parent.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        maxCount -= Time.deltaTime;
        if (maxCount < 0)
            KillMe();
        _transform.Translate(_direction * (Time.deltaTime * 10));
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.CompareTag("Player"))
            Effect();
        KillMe();
    }

    public void Effect()
    {
        if (_isReal)
            _target.GetComponent<CharacterRessources>().GetDamage(_degats);
    }

    void AskDestroy()
    {  
        _transform.parent.GetComponent<pSpawn>().DestroyObject(gameObject);
    }
}
