using UnityEngine;
using System.Collections;

public class pSpawn : MonoBehaviour
{

    public float _time;
    public float _timeFork;
    public GameObject _objectToSpawn;
    public bool _isReal = true;

    protected ParticleSystem _particles;
    protected Transform _transform;
    protected float timeNextSpawn = 0;
    // Use this for initialization
    public void Start()
    {
        _transform = transform;
        _particles = _transform.GetChild(0).GetComponent<ParticleSystem>();
        if (_isReal)
        {
            _particles.startColor = Color.red;
        }
        else
        {
            _particles.startColor = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpawn();
    }

    public void ActiveParticle()
    {
        _particles.Play();
    }

    public void CheckSpawn()
    {
        timeNextSpawn -= Time.deltaTime;
        if (timeNextSpawn < 0)
        {
            GameObject newObject = Instantiate(_objectToSpawn, _transform.position, Quaternion.identity) as GameObject;
            newObject.transform.GetComponent<pEnemy>()._isReal = _isReal;
            newObject.transform.parent = _transform;
            timeNextSpawn = Random.Range((_time - _timeFork), (_time + _timeFork));
        }
    }

    public void DestroyObject(GameObject Object)
    {
        Destroy(Object);
    }
}
