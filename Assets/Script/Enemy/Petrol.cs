using UnityEngine;
using System.Collections;

public class Petrol : pEnemy {
    public GameObject tachePetrol;
    public float _dureeTache;
    public Animator anim;
    public bool exploding =false;
	// Use this for initialization
	void Start () {
        base.Start();
        anim = GetComponent<Animator>();
	}

    public override void Effect()
    {
        if (!_isReal)
            return;

        exploding = true;
        anim.SetBool("exploding",exploding);
        Transform cameraTransform = Camera.main.transform;
        Vector3 angles = new Vector3(-90, 0, 0);
        GameObject tache = Instantiate(tachePetrol, cameraTransform.transform.position + Vector3.forward, Quaternion.Euler(angles)) as GameObject;
        tache.transform.GetComponent<Tache>().Active(_dureeTache);
        tache.transform.parent = cameraTransform;
        Debug.Log(exploding);
        // Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
