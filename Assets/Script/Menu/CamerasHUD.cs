using UnityEngine;
using System.Collections;

public class CamerasHUD : MonoBehaviour {

	public Texture jaugeTexture;
	public Texture jaugeTextureFill;
	
	public Rect jaugeRect = new Rect(Camera.main.pixelWidth - 50,50,75,390);
	
	void Start () {
	
	}
	
	void Update () {
	
	}
	void OnGUI(){
		if(GUI.Button(jaugeRect,jaugeTexture)){
		
		}
	}
	
}
