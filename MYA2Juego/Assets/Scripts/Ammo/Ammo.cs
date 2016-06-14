using UnityEngine;
using System.Collections;
using System;

public abstract class Ammo : MonoBehaviour, IReusable
{
    public float speed;
    public float lifeTime;

    protected float _currentLifetime;

    public virtual void OnAcquire()
    {
        gameObject.SetActive(true);
        _currentLifetime = lifeTime;
    }

    public virtual void OnCreate()
    {
        transform.parent = GameObject.FindGameObjectWithTag(K.TAG_AMMO).transform;
        gameObject.SetActive(false);
    }

    public virtual void OnRelease()
    {
        gameObject.SetActive(false);
    }

    protected virtual void Update()
    {
        _currentLifetime -= Time.deltaTime;
        if (_currentLifetime <= 0)
        {
            GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolBullets.PutBackObject(gameObject);
        }
    }
}
