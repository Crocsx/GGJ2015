using UnityEngine;
using System.Collections;

public class ILife : MonoBehaviour {

    public int _life = 100;
    public int _maxLife = 100;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GetDamage(int damage)
    {
        _life -= damage;
        if (_life <= 0)
        {
            Die();
        }
    }

    public void GetHeal(int heal)
    {
        if (_life + heal <= _maxLife)
        {
            _life += heal;
        }
        else
        {
            _life = _maxLife;
        }
    }

    virtual public void Die()
    {
        //Destroy(gameObject);
    }
}
