using UnityEngine;
using System.Collections;


public class Globe : pEnemy {
    public float _timePerSwitchState;
    public float _timePerAnimation;
    public bool big;
    private float counter;
    private Animator anim;
	// Use this for initialization
	void Start () {
        base.Start();
		anim = GetComponent<Animator>();
		big = false;
		changeStatus();
	}

    public void changeStatus()
    {
		if(big){
			big = false;
			anim.SetBool("GoingBig",true);
   		}
   		else{
			big = true;
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
			Debug.Log("ass");
            changeStatus();
        }
		if(anim.GetBool("GoingBig")){
			if (_isReal && Vector3.Distance(_target.transform.position, transform.position) < 3)
				Effect();
        }
	}
}
