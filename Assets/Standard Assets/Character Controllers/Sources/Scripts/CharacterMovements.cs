using UnityEngine;
using System.Collections;

public class CharacterMovements : MonoBehaviour {

	public float speed = 6.0F;
     public float jumpSpeed = 8.0F; 
     public float gravity = 20.0F;
     private Vector2 moveDirection = Vector2.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		CharacterController controller = GetComponent<CharacterController>();
         // is the controller on the ground?
			moveDirection.x = Input.GetAxis("Horizontal")* speed;
             // moveDirection = new Vector2(Input.GetAxis("Horizontal"),moveDirection.y);
             // moveDirection = transform.TransformDirection(moveDirection);
             //Multiply it by speed.
             // moveDirection *= speed;
         if (controller.isGrounded) {
             //Feed moveDirection with input.
             //Jumping
             if (Input.GetButton("Jump"))
                 moveDirection.y = jumpSpeed;
             
         }
         // else
         // moveDirection.y -= gravity * Time.deltaTime;
         	// Debug.Log("dayum");
         Debug.Log(moveDirection);
         //Applying gravity to the controller
         // if(!controller.isGrounded)
         //Making the character move
         controller.Move(moveDirection * Time.fixedDeltaTime);

	}
}
