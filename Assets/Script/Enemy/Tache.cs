﻿using UnityEngine;
using System.Collections;

public class Tache : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector3.up * Time.deltaTime,Space.World);
	}

    public void Active(float duration)
    {
        Destroy(gameObject, duration);
    }
}
