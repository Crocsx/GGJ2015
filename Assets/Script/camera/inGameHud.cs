using UnityEngine;
using System.Collections;

public class inGameHud : MonoBehaviour {

	public Texture backgroundImage;
	public Texture fillImage;
	public Texture FrontImage;
	
	private CharacterMovements CharactRef;

	void Start () {
		CharactRef = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovements>();
	}
	
	void Update () {
	
	}
	
	void OnGUI(){
		float percent = ((CharactRef.MaxAirTimeLeft - CharactRef.AirTimeLeft) / CharactRef.MaxAirTimeLeft) > 1 ? 1 : (CharactRef.MaxAirTimeLeft - CharactRef.AirTimeLeft) / CharactRef.MaxAirTimeLeft ;
		GUI.DrawTexture(new Rect(Camera.main.pixelWidth - 49 , 58 , 50/2, 238/2),backgroundImage);
		GUI.DrawTexture(new Rect(Camera.main.pixelWidth - 50 , 62 + 110 * percent,45/2,110 - (110 * percent )),fillImage);
		GUI.DrawTexture(new Rect(Camera.main.pixelWidth - 50 , 50 , 50/2, 250/2),FrontImage);
		
	}
}
