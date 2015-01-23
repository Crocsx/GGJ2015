using UnityEngine;
using System.Collections;

public class moveCameraTEST : MonoBehaviour {
	public float speed = 10;

	void Start () {
	
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Translate(speed * transform.right * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Translate(speed * -transform.right * Time.deltaTime);
		}
	}
}
