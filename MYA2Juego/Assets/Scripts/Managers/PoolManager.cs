using UnityEngine;
using System.Collections;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;
    public GameObject prefabBullet, prefabBomb, prefabSmallEnemy, prefabMediumEnemy, prefabBigEnemy, prefabPowerupAutomatic, prefabPowerupLaser, prefabPowerupBomb;
    public ObjectPool<Asteroid> poolSmallEnemies { get; private set; }
    public ObjectPool<Asteroid> poolMediumEnemies { get; private set; }
    public ObjectPool<Asteroid> poolBigEnemies { get; private set; }
    public ObjectPool<Ammo> poolBullets { get; private set; }
    public ObjectPool<Ammo> poolBombs { get; private set; }
    public ObjectPool<Powerup> poolAutomaticPowerUps { get; private set; }
    public ObjectPool<Powerup> poolLaserPowerUps { get; private set; }
    public ObjectPool<Powerup> poolBombPowerUps { get; private set; }
    public ObjectPool<Ammo> poolSuperBombs { get; private set; }

    private void Awake()
    {
        if (instance == null) instance = this;
        poolBullets = new ObjectPool<Ammo>(() => Instantiate(prefabBullet), K.TAG_AMMO);
        poolBombs = new ObjectPool<Ammo>(() => Instantiate(prefabBomb), K.TAG_AMMO);

        poolSmallEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabSmallEnemy), K.TAG_ENEMIES);
        poolMediumEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabMediumEnemy), K.TAG_ENEMIES);
        poolBigEnemies = new ObjectPool<Asteroid>(() => Instantiate(prefabBigEnemy), K.TAG_ENEMIES);

        poolAutomaticPowerUps = new ObjectPool<Powerup>(()=>Instantiate(prefabPowerupAutomatic),K.TAG_POWERUPS);
        poolLaserPowerUps = new ObjectPool<Powerup>(()=>Instantiate(prefabPowerupLaser),K.TAG_POWERUPS);
        poolBombPowerUps = new ObjectPool<Powerup>(()=>Instantiate(prefabPowerupBomb),K.TAG_POWERUPS);
    }
}
