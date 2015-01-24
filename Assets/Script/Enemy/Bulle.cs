using UnityEngine;
using System.Collections;

public class Bulle : pEnemy
{
    public float _speed;
    private Vector3 _direction;
    private float maxCount = 10;
    // Use this for initialization
    void Start()
    {
        base.Start();
        _direction = _transform.parent.up;
    }

    // Update is called once per frame
    void Update()
    {
        maxCount -= Time.deltaTime;
        if (maxCount < 0)
            KillMe();
        _transform.Translate(_direction * (Time.deltaTime * _speed));
    }

    void OnCollisionEnter2D(Collision2D coll) 
    {
        Vector3 pos = _transform.position;
        if (coll.transform.CompareTag("Map"))
        {
            KillMe();
            return;
        }
        if (coll.transform.CompareTag("Player"))
            Effect();
        Physics2D.IgnoreCollision(_transform.collider2D, coll.transform.collider2D);
        _transform.position = pos;
    }

    public override void Effect()
    {
        if (_isReal)
            _target.position = _target.position + _direction;
    }

    void AskDestroy()
    {
        _transform.parent.GetComponent<pSpawn>().DestroyObject(gameObject);
    }
}
