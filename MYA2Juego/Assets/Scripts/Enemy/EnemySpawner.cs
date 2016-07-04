using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public static int asteroidsCount = K.ASTEROIDS_COUNT_LEVEL1;
    public GameObject asteroidPrefabToClone;

    private float _timer;
    private ObjectPool<Asteroid>[] _poolManagerRef;
    private Asteroid _asteroidToClone;

    private void Start()
    {
        _poolManagerRef = new ObjectPool<Asteroid>[3];
        _poolManagerRef[0] = PoolManager.instance.poolSmallEnemies;
        _poolManagerRef[1] = PoolManager.instance.poolMediumEnemies;
        _poolManagerRef[2] = PoolManager.instance.poolBigEnemies;

        _asteroidToClone = Instantiate(asteroidPrefabToClone).GetComponent<Asteroid>();
        _asteroidToClone.gameObject.SetActive(false);
        _asteroidToClone.transform.parent = transform;
        // SETEO DE DECORATORS SEGUN ASTEROID
        switch (_asteroidToClone.gameObject.layer)
        {
            case K.LAYER_SMALL_ASTEROID:
                _asteroidToClone.SetDecorator(new DecoratorAsteroidZigZag(new DecoratorAsteroidScale()));
                break;
            case K.LAYER_MEDIUM_ASTEROID:
                _asteroidToClone.SetDecorator(new DecoratorAsteroidScale(new DecoratorAsteroidRotate()));
                break;
            case K.LAYER_BIG_ASTEROID:
                _asteroidToClone.SetDecorator(new DecoratorAsteroidRotate(new DecoratorAsteroidZigZag()));
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0 && asteroidsCount > 0)
        {
            _timer = K.ASTEROIDS_SPAWN_TIMER;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        asteroidsCount--;
        var go = _asteroidToClone.Clone();
        go.transform.position = transform.position;
        float cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;
        Vector3 randomDirection = new Vector3(Random.Range(-cameraWidth, cameraWidth), Random.Range(-cameraWidth, cameraWidth), 0);
        go.transform.up = randomDirection - go.transform.up;
    }
}
