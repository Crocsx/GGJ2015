using UnityEngine;
using System.Collections;

public class Shark : pEnemy {

    public int _distanceParcour;
    public float _timeForMove;
    public bool _side;

    private Vector3 _posMaxLeft;
    private Vector3 _posMaxRight;
    private Vector3 _posTarget;
    private Vector3 _posActual;
    private float counter;
	// Use this for initialization
	void Start () {
        base.Start();
        _posMaxLeft = _transform.position - new Vector3(_distanceParcour * 0.5f, 0, 0);
        _posMaxRight = _transform.position + new Vector3(_distanceParcour * 0.5f, 0,0);
        _posTarget = _side ? _posMaxLeft : _posMaxRight;
        _posActual = _transform.position;
        counter = _distanceParcour*0.5f; 
	}
    public override void Effect()
    {
        _target.GetComponent<CharacterRessources>().GetDamage(_degats); 
    }

	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        Vector3 newMove = Vector3.Lerp(_posActual, _posTarget, counter/_timeForMove);
        _transform.position = newMove;

        if (_side && _transform.position.x <= _posTarget.x)
            SwitchSide();
        else if (!_side && _transform.position.x >= _posTarget.x)
            SwitchSide();
	}

    void SwitchSide()
    {
        _side = !_side;
        _posActual = _posTarget;
        _posTarget = _side ? _posMaxLeft : _posMaxRight;
        counter = 0;
    }
}
