using UnityEngine;
using System.Collections;

public class Bulle : pEnemy
{
    public float _speed;
    private Vector3 _direction;
    // Use this for initialization
    void Start()
    {
        base.Start();
        _direction = _transform.parent.up;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.Translate(_direction * (Time.deltaTime * _speed));
    }

    public override void Effect()
    {
        _target.position = _target.position + _direction;
    }

    void AskDestroy()
    {
        _transform.parent.GetComponent<pSpawn>().DestroyObject(gameObject);
    }
}
