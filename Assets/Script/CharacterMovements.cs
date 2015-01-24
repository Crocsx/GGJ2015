using UnityEngine;
using System.Collections;

public class CharacterMovements : MonoBehaviour {

	public float maxSpeed = 10F;
     public bool facingRight =true ; 
     public bool _grounded = false;
     public LayerMask groundLayer;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2(move*maxSpeed, rigidbody2D.velocity.y);

		if(move > 0 && !facingRight) {
			Flip();
		}else if(move<0 && facingRight){
			Flip();
		}
		
		// RaycastHit hit;
		if(Physics2D.Raycast(transform.position, -Vector2.up, renderer.bounds.size.y * 0.7f)){
			_grounded = true;
		}else
			_grounded = false;

		if(Input.GetButton("Jump")&& _grounded){
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, maxSpeed);// maxSpeed;
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}


}
