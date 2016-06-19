using UnityEngine;
using System.Collections;
using System;

public class ShootTypeLaser : IStrategyShootType
{
    private float _maxDistanceLaser = Config.LASER_MAX_DISTANCE;

    public void SpawnBullet(Transform playerTransform, ObjectPool<Ammo> bulletPool)
    {
        Ray2D ray = new Ray2D(playerTransform.position, playerTransform.up);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(ray.origin, ray.direction, _maxDistanceLaser);
        if (hit)
        {
            Debug.Log(hit.collider.gameObject);
        }
    }

    public void Update()
    {
    }
}
