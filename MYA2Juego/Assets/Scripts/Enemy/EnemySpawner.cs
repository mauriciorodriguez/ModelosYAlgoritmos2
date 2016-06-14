using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public static int asteroidsCount = K.ASTEROIDS_COUNT_LEVEL1;

    private float _timer;
    private ObjectPool<Asteroid>[] _poolManagerRef;

    private void Start()
    {
        _poolManagerRef = new ObjectPool<Asteroid>[3];
        _poolManagerRef[0] = GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolSmallEnemies;
        _poolManagerRef[1] = GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolMediumEnemies;
        _poolManagerRef[2] = GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolBigEnemies;
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
        var go = _poolManagerRef[Mathf.FloorToInt(Random.Range(0, 3))].GetObject();
        go.transform.position = transform.position;
        Vector2 randomDirection;
        randomDirection.x = Random.Range(0, 360);
        randomDirection.y = Random.Range(0, 360);
        go.transform.up = randomDirection;
    }
}
