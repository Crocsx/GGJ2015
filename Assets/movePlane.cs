using UnityEngine;
using System.Collections;

public class movePlane : MonoBehaviour {
	
	public float speed = 1;
	
	private float TextureOffset = 0;
	private Vector3 offsetFromCamera;
	private Vector3 newOffsetFromCamera;
	

	void Start () {
		transform.localScale = new Vector3(Camera.main.orthographicSize * Camera.main.rect.width,1,0.2f *Camera.main.orthographicSize * Camera.main.rect.height);
	}
	
	void LateUpdate () {
		newOffsetFromCamera = offsetFromCamera - (transform.position - Camera.main.transform.position);
		TextureOffset += newOffsetFromCamera.x * speed * 0.005f;
		transform.position = new Vector3(Camera.main.transform.position.x,Camera.main.transform.position.y,transform.position.z);
		renderer.material.mainTextureOffset = new Vector2(TextureOffset,0);
		offsetFromCamera = transform.position - Camera.main.transform.position;
	}
}