using UnityEngine;
using System.Collections;
using System;

public class ShootTypeAutomatic : IStrategyShootType
{
    private float _shootRate;
    private float _currentShootRate;

    public ShootTypeAutomatic(float shootRate)
    {
        _shootRate = shootRate;
    }

    public void SpawnBullet(Transform playerTransform, ObjectPool<Bullet> bulletPool)
    {
        if (_currentShootRate <= 0)
        {
            var bullet = bulletPool.GetObject();
            bullet.transform.position = playerTransform.position;
            bullet.transform.up = playerTransform.up;
            _currentShootRate = _shootRate;
        }
    }

    public void Update()
    {
        if (_currentShootRate > 0)
        {
            _currentShootRate -= Time.deltaTime;
        }
    }
}
