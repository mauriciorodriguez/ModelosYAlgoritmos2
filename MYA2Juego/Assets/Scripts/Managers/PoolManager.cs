﻿using UnityEngine;
using System.Collections;

public class PoolManager : MonoBehaviour
{
    public GameObject prefabBullet, prefabBomb, prefabSmallEnemy, prefabMediumEnemy, prefabBigEnemy, prefabSuperBomb;
    public ObjectPool<Asteroid> poolSmallEnemies { get; private set; }
    public ObjectPool<Asteroid> poolMediumEnemies { get; private set; }
    public ObjectPool<Asteroid> poolBigEnemies { get; private set; }
    public ObjectPool<Ammo> poolBullets { get; private set; }
    public ObjectPool<Ammo> poolBombs { get; private set; }
    public ObjectPool<IPowerup> poolPowerUps { get; private set; }

    public ObjectPool<Ammo> poolSuperBombs { get; private set; }

    private void Awake()
    {
        poolBullets = new ObjectPool<Ammo>(() => Instantiate(prefabBullet), K.TAG_AMMO);
        poolBombs = new ObjectPool<Ammo>(() => Instantiate(prefabBomb), K.TAG_AMMO);
        poolSuperBombs = new ObjectPool<Ammo>(() => Instantiate(prefabSuperBomb), K.TAG_AMMO);

        poolSmallEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabSmallEnemy), K.TAG_ENEMIES, SetSmallEnemiesDecorators());
        poolMediumEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabMediumEnemy), K.TAG_ENEMIES, SetMediumEnemiesDecorators());
        poolBigEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabBigEnemy), K.TAG_ENEMIES, SetBigEnemiesDecorators());
    }

    private IDecoratorAsteroid SetSmallEnemiesDecorators()
    {
        return null;//new DecoratorAsteroidZigZag(); // TODO
    }

    private IDecoratorAsteroid SetMediumEnemiesDecorators()
    {
        return null; // TODO
    }

    private IDecoratorAsteroid SetBigEnemiesDecorators()
    {
        return null; // TODO
    }
}
