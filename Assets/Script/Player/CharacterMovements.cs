using UnityEngine;
using System.Collections;

public class CharacterMovements : MonoBehaviour {
    public bool freezed = false; 
	public float maxSpeed = 10F;
     public bool facingRight =true ; 
     public bool _grounded = false;
     public Transform groundLabel;
     private Animator anim;
     public bool isActiveJetPack =false;
    
    public float AirTimeLeft = 10;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
    void Update()
    {

    	// if(isActiveJetPack)
    		// isActiveJetPack = false;
        if (freezed)
            return;
		AirTimeLeft -= Time.deltaTime;
		if(AirTimeLeft < 0){
			// Debug.LogWarning("NO MORE AIR!!!");
		}
		
		// if(Input.GetAxis("Horizontal")!=0)
		float move = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2(move*maxSpeed, rigidbody2D.velocity.y);
			anim.SetFloat("speed", Mathf.Abs(move));
			anim.SetBool("isGrounded", _grounded);
			anim.SetBool("isActiveJetPack", isActiveJetPack);

		if(move > 0 && !facingRight) {
			Flip();
		}else if(move<0 && facingRight){
			Flip();
		}
		
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up,renderer.bounds.size.y *0.7f,~(1 << 9));
		if(hit.distance > 0){
			_grounded = true;
				isActiveJetPack = false;
		}else
			_grounded = false;

		if(Input.GetButton("Jump")){

			if(_grounded){
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, maxSpeed*0.5f);//jump
			}else
			if( AirTimeLeft > 0 && rigidbody2D.velocity.y < 0){
				isActiveJetPack = true;
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, maxSpeed);//boost
				AirTimeLeft -= 1;
			}
		}		
	}

    public void Freeze(int duration)
    {
        freezed = true;
        Invoke("deFreeze", duration);
    }
    public void deFreeze()
    {
        freezed = false;
    }
	void Flip(){
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}


}
