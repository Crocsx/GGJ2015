using UnityEngine;
using System.Collections;

public class WatcherAbilities : MonoBehaviour {

	public GameObject sonar;
	public Camera watcherCam;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Mouse0)){
			// Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			// Physics.Raycast()
			Ray ray = watcherCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				Vector3 TargetPoint = new Vector3(hit.point.x, hit.point.y, 0);
				GameObject go = Instantiate(sonar, TargetPoint, Quaternion.identity) as GameObject;
				Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));
			}
		}
	}
}
