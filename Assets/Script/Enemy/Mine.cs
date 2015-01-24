using UnityEngine;
using System.Collections;

public class Mine : pEnemy {
    public float _timeBeforeExplosion;
    public float _detectionRange;
	
	private Animator anim;
	private bool activated = false;
    private float countdown;
	// Use this for initialization
    void Start()
    {
    	base.Start();	
		countdown = _timeBeforeExplosion;
		anim = GetComponent<Animator>();
    }
    

    public override void Effect()
    {
        if (_isReal)
            _target.GetComponent<CharacterRessources>().GetDamage(_degats);
		
		anim.SetBool("exploding",true);
		Invoke("exploseMine",0.65f);
    }
    
	void exploseMine(){
		KillMe();
	}

	// Update is called once per frame
	void Update () {
		if(activated)
            countdown -= Time.deltaTime;
            
		if(countdown<0 && !anim.GetBool("exploding"))
			Effect();
		
	    if(Vector3.Distance(_target.transform.position, transform.position) < _detectionRange){
	    Debug.Log("activated");
        	activated = true;
        }
	}
}
