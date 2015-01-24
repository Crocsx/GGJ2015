using UnityEngine;
using System.Collections;

public class Murene : pEnemy
{

    public int _distanceParcour;
    public float _timeForMove;
    public bool _side;
    public bool _top;
    public float _dureeFreeze;

    private Vector3 _posMax1;
    private Vector3 _posMax2;
    private Vector3 _posTarget;
    private Vector3 _posActual;
    private float counter;
    // Use this for initialization
    void Start()
    {
        base.Start();
        if (!_top)
        {
            _posMax1 = _transform.position - new Vector3(_distanceParcour * 0.5f, 0, 0);
            _posMax2 = _transform.position + new Vector3(_distanceParcour * 0.5f, 0, 0);
        }
        else
        {
            _posMax1 = _transform.position - new Vector3(0,_distanceParcour * 0.5f, 0);
            _posMax2 = _transform.position + new Vector3(0,_distanceParcour * 0.5f, 0);
        }
        _posTarget = _side ? _posMax1 : _posMax2;
        _posActual = _transform.position;
        counter = _distanceParcour * 0.5f;
    }
    public override void Effect()
    {
        if (_isReal)
            _target.GetComponent<CharacterMovements>().Freeze(_dureeFreeze);
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        Vector3 newMove = Vector3.Lerp(_posActual, _posTarget, counter / _timeForMove);
        _transform.position = newMove;

        if (!_top)
        {
            if (_side && _transform.position.x <= _posTarget.x)
                SwitchSide();
            else if (!_side && _transform.position.x >= _posTarget.x)
                SwitchSide();
        }
        else
        {
            if (_side && _transform.position.y <= _posTarget.y)
                SwitchSide();
            else if (!_side && _transform.position.y >= _posTarget.y)
                SwitchSide();
        }
    }

    void SwitchSide()
    {
        _side = !_side;
        _posActual = _posTarget;
        _posTarget = _side ? _posMax1 : _posMax2;
        counter = 0;
    }
}
