using UnityEngine;
using System.Collections;

public class CharacterMovements : MonoBehaviour {

	public float maxSpeed = 10F;
     public bool facingRight =true ; 
     public bool _grounded = false;
     public Transform groundLabel;
    
    public float AirTimeLeft = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		AirTimeLeft -= Time.deltaTime;
		if(AirTimeLeft < 0){
			Debug.LogWarning("NO MORE AIR!!!");
		}
		
		float move = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2(move*maxSpeed, rigidbody2D.velocity.y);

		if(move > 0 && !facingRight) {
			Flip();
		}else if(move<0 && facingRight){
			Flip();
		}
		
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up,renderer.bounds.size.y *0.7f,~(1 << 9));
		if(hit.distance > 0){
			_grounded = true;
		}else
			_grounded = false;

		if(Input.GetButton("Jump")){
			if(_grounded){
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, maxSpeed);//jump
			}
			if( AirTimeLeft > 0 && rigidbody2D.velocity.y < 0){
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, maxSpeed);//boost
				AirTimeLeft -= 1;
			}
		}
		
		Vector2 horizontalMove = rigidbody2D.velocity;
		horizontalMove.y = 0;
		for(int i = 0;i < 2; i++){
			hit = Physics2D.Raycast( new Vector2(transform.position.x,transform.position.y - renderer.bounds.size.y * 0.5f + renderer.bounds.size.y *i),horizontalMove,renderer.bounds.size.y *0.55f,~(1<<9));
			if(hit.distance > 0)
				rigidbody2D.velocity = new Vector3(0, rigidbody2D.velocity.y, 0);
		}
		
	}
	
	void Flip(){
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}


}
