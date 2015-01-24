using UnityEngine;
using System.Collections;

public class Mine : pEnemy {
    public float _timeBeforeExplosion;
    public float _detectionRange;
    public int _degats;

    private float countdown;
	// Use this for initialization
    void Start()
    {
        base.Start();
    }

    public override void Effect()
    {
        _target.GetComponent<CharacterRessources>().GetDamage(_degats);
    }

	// Update is called once per frame
	void Update () {
	    if(Vector3.Distance(_target.transform.position, transform.position) < _detectionRange){
            countdown -= Time.deltaTime;
            if(countdown<0)
                Effect();
        }
        else{
            countdown = _timeBeforeExplosion;
        }
	}
}
