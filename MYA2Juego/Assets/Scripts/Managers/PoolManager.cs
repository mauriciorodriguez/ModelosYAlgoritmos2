using UnityEngine;
using System.Collections;

public class PoolManager : MonoBehaviour
{
    public GameObject prefabBullet, prefabSmallEnemy, prefabMediumEnemy, prefabBigEnemy;
    public ObjectPool<Asteroid> poolSmallEnemies { get; private set; }
    public ObjectPool<Asteroid> poolMediumEnemies { get; private set; }
    public ObjectPool<Asteroid> poolBigEnemies { get; private set; }
    public ObjectPool<Bullet> poolBullets { get; private set; }
    public ObjectPool<Bullet> poolBombs { get; private set; }
    public ObjectPool<IPowerup> poolPowerUps { get; private set; }

    private void Awake()
    {
        poolBullets = new ObjectPool<Bullet>(() => Instantiate(prefabBullet), K.TAG_BULLETS);
        poolSmallEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabSmallEnemy), K.TAG_ENEMIES);
        poolMediumEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabMediumEnemy), K.TAG_ENEMIES);
        poolBigEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabSmallEnemy), K.TAG_ENEMIES);
    }
}
