using UnityEngine;
using System.Collections;

public class WatcherAbilities : MonoBehaviour {

	public GameObject sonar;
	public GameObject torpedoExplo;
	public Camera watcherCam;
	public string pointerMode = "Sonar";
	// Use this for initialization
	public float rechargeTime = 2;	
	private float timeSinceFire = 10;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		timeSinceFire += Time.deltaTime;
		if(Input.GetKeyUp(KeyCode.Mouse0)){
		
			if(pointerMode == "Sonar"){
				Ray ray = watcherCam.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 100) && timeSinceFire >= rechargeTime) {
					timeSinceFire = 0;
					Vector3 TargetPoint = new Vector3(hit.point.x, hit.point.y, 0);
					Instantiate(sonar, TargetPoint, Quaternion.identity);
					// Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));
				}
				else
					Debug.Log("Time Left Before next Sonar: "+ (rechargeTime - timeSinceFire));
			}
			else if(pointerMode == "Torpedo"){
				Ray ray = watcherCam.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if(Physics.Raycast (ray, out hit, 100)){
					Vector3 TargetPoint = new Vector3(hit.point.x, hit.point.y, 0);
					GameObject torpedoGo = Instantiate(torpedoExplo, TargetPoint, Quaternion.identity) as GameObject;
					Collider2D colli = Physics2D.OverlapCircle(torpedoGo.transform.position,torpedoGo.renderer.bounds.size.x *0.4f);
					if(colli){
						if(colli.gameObject.layer == 10){
							Destroy(colli.gameObject);
						}
					}
				}
			}
				
		}
	}
}
