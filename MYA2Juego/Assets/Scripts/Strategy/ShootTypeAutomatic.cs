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

    public void SpawnBullet(Transform playerTransform, ObjectPool<Ammo> bulletPool)
    {
        if (_currentShootRate <= 0)
        {
            var bullet = bulletPool.GetObject();
            Debug.Log(bullet);
            bullet.transform.position = playerTransform.position; // TODO : Sumar la mitad del alto del sprite de la nave
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
