using UnityEngine;
using System.Collections;

public class Meduse : pEnemy
{

    public int _distanceParcour;
    public float _timeForMove;
    public bool _side;

    private Vector3 _posMaxBot;
    private Vector3 _posMaxTop;
    private Vector3 _posTarget;
    private Vector3 _posActual;
    private float counter;
    // Use this for initialization
    void Start()
    {
        base.Start();
        _posMaxBot = _transform.position - new Vector3(0, _distanceParcour * 0.5f, 0);
        _posMaxTop = _transform.position + new Vector3(0, _distanceParcour * 0.5f, 0);
        _posTarget = _side ? _posMaxBot : _posMaxTop;
        _posActual = _transform.position;
        counter = _distanceParcour * 0.5f;
    }
    public override void Effect()
    {
        _target.GetComponent<CharacterRessources>().GetDamage(_degats);
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        Vector3 newMove = Vector3.Lerp(_posActual, _posTarget, counter / _timeForMove);
        _transform.position = newMove;

        if (_side && _transform.position.y <= _posTarget.y)
            SwitchSide();
        else if (!_side && _transform.position.y >= _posTarget.y)
            SwitchSide();
    }

    void SwitchSide()
    {
        _side = !_side;
        _posActual = _posTarget;
        _posTarget = _side ? _posMaxBot : _posMaxTop;
        counter = 0;
    }
}
