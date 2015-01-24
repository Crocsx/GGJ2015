using UnityEngine;
using System.Collections;

public class Tache : MonoBehaviour {
    public float duration;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("Destroy", duration);
	}

    void Destroy()
    {
        GameObject.Destroy(this);
    }
}
