using UnityEngine;
using System.Collections;

public class CharacterRessources : ILife {
	// Use this for initialization

	public bool isDead;

	private Animator anim;
	
	void Start () {
		isDead = false;
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Die()
    {
        isDead = true;
		anim.SetBool("isDead", isDead);
    }
}
