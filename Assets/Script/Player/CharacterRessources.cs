using UnityEngine;
using System.Collections;

public class CharacterRessources : ILife {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Die()
    {
        Debug.Log("Lose");
    }
}
