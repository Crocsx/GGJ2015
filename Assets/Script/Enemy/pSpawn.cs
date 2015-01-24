using UnityEngine;
using System.Collections;

public class pSpawn : MonoBehaviour
{

    public float _time;
    public float _timeFork;
    public GameObject _objectToSpawn;

    protected Transform _transform;
    protected float timeNextSpawn = 0;
    // Use this for initialization
    public void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpawn();
    }

    public void CheckSpawn()
    {
        timeNextSpawn -= Time.deltaTime;
        if (timeNextSpawn < 0)
        {
            GameObject newObject = Instantiate(_objectToSpawn, _transform.position + _transform.up, Quaternion.identity) as GameObject;
            newObject.transform.parent = _transform;
            timeNextSpawn = Random.Range((_time - _timeFork), (_time + _timeFork));
        }
    }

    public void DestroyObject(GameObject Object)
    {
        Destroy(Object);
    }
}
