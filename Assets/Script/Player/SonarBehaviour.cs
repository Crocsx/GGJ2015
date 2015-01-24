using UnityEngine;
using System.Collections;

public class SonarBehaviour : MonoBehaviour {

	public float maxSize;
	// Use this for initialization
	void Start () {
		maxSize = 100F;
	}
	
	// Update is called once per frame
	void Update () {
		

		if(transform.localScale.magnitude <= maxSize)
			transform.localScale *= 1.1f;
			else
			Destroy(gameObject);
		}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.layer == 10){
			Debug.Log("thing detected");
			col.renderer.material.color = Color.red;
		}


	}
}
