using UnityEngine;
using System.Collections;

public class Tache : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Active(float duration)
    {
        Debug.Log("duration");
        Invoke("killMe", duration);
    }
    void killMe()
    {
        Debug.Log("kill");
        GameObject.Destroy(this);
    }
}
