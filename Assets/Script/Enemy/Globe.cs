using UnityEngine;
using System.Collections;


public class Globe : pEnemy {
    public float _timePerSwitchState;
    public float _timePerAnimation;
    public int currentState;
    private enum globeState : byte { big = 1, goingBig, goingSmall, Small};
    private float counter;
	// Use this for initialization
	void Start () {
        base.Start();
        changeStatus();
        currentState = 1;
	}

    public void changeStatus()
    {
    }

    public override void Effect()
    {
        if (_isReal)
            _target.GetComponent<CharacterRessources>().GetDamage(_degats);
    }

	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        if (counter > _timePerSwitchState)
        {
            changeStatus();
        }
	}
}
