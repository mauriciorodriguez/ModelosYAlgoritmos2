using UnityEngine;
using System.Collections;
using System;

public class Bomb : Ammo
{
    protected override void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        base.Update();
        if (_currentLifetime <= 0)
        {
            PoolManager.instance.poolBombs.PutBackObject(gameObject);
        }
    }
}
