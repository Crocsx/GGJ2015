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
        Vector3 angles = new Vector3(-90, 0, 0);
        Transform tache = Instantiate(tachePetrol, cameraTransform.transform.position + Vector3.forward, Quaternion.Euler(angles)) as Transform;
        tache.transform.GetComponent<Tache>().Active(_dureeTache);
        tache.parent = cameraTransform;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
