using UnityEngine;
using System.Collections;

public class Murene : pEnemy
{

    public int _distanceParcour;
    public int _detectionRange;
    public float _timeForMove;
    public bool _side;
    public bool _goesTop;
    public float _dureeFreeze;

    private bool isPlaying;
    private Vector3 _posMax1;
    private Vector3 _posMax2;
    private Vector3 _posTarget;
    private Vector3 _posActual;
    // Use this for initialization
    void Start()
    {
        base.Start();
        isPlaying=false;
        if (!_goesTop)
        {
            _posMax1 = _transform.position;
            _posMax2 = _transform.position + new Vector3(_distanceParcour, 0, 0);
        }
        else
        {
            _posMax1 = _transform.position;
            _posMax2 = _transform.position + new Vector3(0,_distanceParcour, 0);
        }
        _posTarget = _side ? _posMax1 : _posMax2;
        _posActual = _transform.position;
    }
    public override void Effect()
    {
        if (_isReal)
            _target.GetComponent<CharacterMovements>().Freeze(_dureeFreeze);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying && Vector3.Distance(_target.transform.position, transform.position) < _detectionRange)
        {
            StartCoroutine(Mvt());
            isPlaying = true;
        }
    }

    public IEnumerator Mvt()
    {
        _posTarget = _side ? _posMax1 : _posMax2;
        float totalTime = 0;
        float stepMove = 0;
        while (totalTime < _timeForMove)
        {
            stepMove += Time.deltaTime;
            totalTime += Time.deltaTime;
            Vector3 newMove = Vector3.Lerp(_posActual, _posTarget, stepMove/(_timeForMove * 0.5F) );
            _transform.position = newMove;

            if (!_goesTop)
            {
                if ((_side && _transform.position.x <= _posTarget.x) || (!_side && _transform.position.x >= _posTarget.x)){
                    SwitchSide();
                    stepMove = 0;
                }
            }
            else
            {
                if ((_side && _transform.position.y <= _posTarget.y) || (!_side && _transform.position.y >= _posTarget.y)) { 
                    SwitchSide();
                    stepMove = 0;
                }
            }
            yield return null;
        }
        transform.position = _posMax1;
        isPlaying = false;
    }

    void SwitchSide()
    {
        _side = !_side;
        _posActual = _posTarget;
        _posTarget = _side ? _posMax1 : _posMax2;
    }
}
