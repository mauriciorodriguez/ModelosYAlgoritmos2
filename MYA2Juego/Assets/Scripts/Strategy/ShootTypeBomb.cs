using UnityEngine;
using System.Collections;
using System;

public class ShootTypeBomb : IStrategyShootType
{
    private float _shootRate, _currentShootRate;

    public ShootTypeBomb(float shootRate)
    {
        _shootRate = shootRate;
    }

    public void SpawnBullet(Transform playerTransform, ObjectPool<Ammo> bulletPool)
    {
        if (_currentShootRate <= 0)
        {
            var bullet = bulletPool.GetObject();
            bullet.transform.position = playerTransform.position; // TODO : Sumar la mitad del alto del sprite de la nave
            bullet.transform.up = -playerTransform.up;
            _currentShootRate = _shootRate;
        }
    }

    public void Update()
    {
        if (_currentShootRate> 0)
        {
            _currentShootRate -= Time.deltaTime;
        }
    }
}
