using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Powerup : MonoBehaviour, IReusable
{
    public string namePowerup;
    public float lifeTime;

    private float _currentLifetime;

    public virtual void OnAcquire()
    {
        gameObject.SetActive(true);
        _currentLifetime = lifeTime;
    }

    public virtual void OnCreate()
    {
        transform.parent = GameObject.FindGameObjectWithTag(K.TAG_POWERUPS).transform;
        gameObject.SetActive(false);
    }

    public virtual void OnRelease()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        _currentLifetime -= Time.deltaTime;
        if (_currentLifetime <= 0)
        {
            switch (namePowerup)
            {
                case K.POWERUP_AUTOMATIC:
                    PoolManager.instance.poolAutomaticPowerUps.PutBackObject(gameObject);
                    break;
                case K.POWERUP_LASER:
                    PoolManager.instance.poolLaserPowerUps.PutBackObject(gameObject);
                    break;
                case K.POWERUP_BOMB:
                    PoolManager.instance.poolBombPowerUps.PutBackObject(gameObject);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer == K.LAYER_PLAYER)
        {
            var player = coll.gameObject.GetComponent<InputControllerPlayer>();
            player.PowerupGrab(namePowerup);
            Destroy(gameObject);
        }
    }
}
