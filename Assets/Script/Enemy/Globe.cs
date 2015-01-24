using UnityEngine;
using System.Collections;


public class Globe : pEnemy {
    public float _timePerSwitchState = 2;
    public float _timePerAnimation = 2;
    public bool small;
    private float counter;
    private Animator anim;
	// Use this for initialization
	void Start () {
        base.Start();
        _isReal = true;
		anim = GetComponent<Animator>();
		small = false;
		changeStatus();
	}

    public void changeStatus()
    {
		if(small){
			small = false;
			anim.SetBool("GoingBig",true);
   		}
   		else{
			small = true;
			anim.SetBool("GoingBig",false);
   		}
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
			counter = 0;
            changeStatus();
        }
		if(!small){
			if (_isReal && Vector3.Distance(_target.transform.position, transform.position) < 3)
				Effect();
        }
	}
}
