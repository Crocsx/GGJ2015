using UnityEngine;
using System.Collections;

public class movePlane : MonoBehaviour {
	
	public float speed = 1;
	
	private float TextureOffset = 0;
	private Vector3 offsetFromCamera;
	private Vector3 newOffsetFromCamera;
	

	void Start () {
	}
	
	void Update () {
		newOffsetFromCamera = offsetFromCamera - (transform.position - Camera.main.transform.position);
		TextureOffset += newOffsetFromCamera.x * speed * 0.005f;
		transform.position = new Vector3(Camera.main.transform.position.x,Camera.main.transform.position.y,transform.position.z);
		renderer.material.mainTextureOffset = new Vector2(TextureOffset,0);
		offsetFromCamera = transform.position - Camera.main.transform.position;
	}
}
