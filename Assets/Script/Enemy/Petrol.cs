using UnityEngine;
using System.Collections;

public class Petrol : pEnemy {
    public GameObject tachePetrol;
    public float _dureeTache;
	// Use this for initialization
	void Start () {
        base.Start();
	}

    public override void Effect()
    {
        Transform cameraTransform = Camera.main.transform;
        Transform tache = Instantiate(tachePetrol, transform.position, Quaternion.identity) as Transform;
        tache.transform.GetComponent<Tache>().duration = _dureeTache;
        tache.parent = cameraTransform;
        tache.LookAt(cameraTransform);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
