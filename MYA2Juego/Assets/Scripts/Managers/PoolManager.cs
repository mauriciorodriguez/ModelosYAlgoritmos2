﻿using UnityEngine;
using System.Collections;

public class PoolManager : MonoBehaviour
{
    public GameObject prefabBullet, prefabBomb, prefabSmallEnemy, prefabMediumEnemy, prefabBigEnemy;
    public ObjectPool<Asteroid> poolSmallEnemies { get; private set; }
    public ObjectPool<Asteroid> poolMediumEnemies { get; private set; }
    public ObjectPool<Asteroid> poolBigEnemies { get; private set; }
    public ObjectPool<Ammo> poolBullets { get; private set; }
    public ObjectPool<Ammo> poolBombs { get; private set; }
    public ObjectPool<IPowerup> poolPowerUps { get; private set; }

    private void Awake()
    {
        poolBullets = new ObjectPool<Ammo>(() => Instantiate(prefabBullet), Config.TAG_AMMO, 10);
        poolBombs = new ObjectPool<Ammo>(() => Instantiate(prefabBomb), Config.TAG_AMMO);
        poolSmallEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabSmallEnemy), Config.TAG_ENEMIES);
        poolMediumEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabMediumEnemy), Config.TAG_ENEMIES);
        poolBigEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabBigEnemy), Config.TAG_ENEMIES);
    }
}
