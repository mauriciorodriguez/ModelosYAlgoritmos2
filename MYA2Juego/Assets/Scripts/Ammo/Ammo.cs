using UnityEngine;
using System.Collections;
using System;

public abstract class Ammo : MonoBehaviourCameraBounds, IReusable
{
    public float speed, lifeTime, damage;

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

    protected override void Update()
    {
        base.Update();
        _currentLifetime -= Time.deltaTime;        
    }
}
