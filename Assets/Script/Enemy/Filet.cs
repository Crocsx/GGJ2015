using UnityEngine;
using System.Collections;

public class Filet : pEnemy {
    public int _dureeFreeze;
	// Use this for initialization
	void Start () {
        base.Start();
	}

    public override void Effect()
    {
        _target.GetComponent<CharacterMovements>().Freeze(_dureeFreeze);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
