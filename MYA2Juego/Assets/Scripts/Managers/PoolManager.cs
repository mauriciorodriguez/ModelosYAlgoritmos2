using UnityEngine;
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
        poolBullets = new ObjectPool<Ammo>(() => Instantiate(prefabBullet), Config.TAG_AMMO);
        poolBombs = new ObjectPool<Ammo>(() => Instantiate(prefabBomb), Config.TAG_AMMO);
        poolSmallEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabSmallEnemy), Config.TAG_ENEMIES, SetSmallEnemiesDecorators());
        poolMediumEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabMediumEnemy), Config.TAG_ENEMIES, SetMediumEnemiesDecorators());
        poolBigEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabBigEnemy), Config.TAG_ENEMIES, SetBigEnemiesDecorators());
    }

    private IDecoratorAsteroid SetSmallEnemiesDecorators()
    {
        return new DecoratorAsteroidZigZag(); // TODO
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
