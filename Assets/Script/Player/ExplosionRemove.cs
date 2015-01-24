using UnityEngine;
using System.Collections;

public class ExplosionRemove : MonoBehaviour {
	
	private Animator customAnim;
	void Start () {
		customAnim = GetComponent<Animator>();
	}
	
	void Update () {
		if(customAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > customAnim.GetCurrentAnimatorStateInfo(0).length){
			Destroy(gameObject);
		}
	}
}
