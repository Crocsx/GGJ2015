using UnityEngine;
using System.Collections;

public class pEnemy : MonoBehaviour {
    public int _degats;
    public bool _isReal = true;
    protected Transform _transform;
    protected Transform _target;
    protected ParticleSystem _particles;
	// Use this for initialization
	public void Start () {
        _transform = transform;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _particles = _transform.GetChild(0).GetComponent<ParticleSystem>();
        if (_isReal)
        {
            _particles.startColor = Color.red;
        }
        else{
            _particles.startColor = Color.white;
        }
	}

    public void ActiveParticle()
    {
        _particles.Play();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
            Effect();
    }
    public virtual void Effect()
    {
        if (_isReal)
            _target.GetComponent<CharacterRessources>().GetDamage(_degats);
    }

    public void KillMe()
    {
        GameObject.Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
    
    }
}
