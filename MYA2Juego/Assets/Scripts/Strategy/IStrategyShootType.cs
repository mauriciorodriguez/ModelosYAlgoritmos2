using UnityEngine;
using System.Collections;

public interface IStrategyShootType
{
    void Update();
    void SpawnBullet(Transform playerTransform, ObjectPool<Ammo> bulletPool);
}
