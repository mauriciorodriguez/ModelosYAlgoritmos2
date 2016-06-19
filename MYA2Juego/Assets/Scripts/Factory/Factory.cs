using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Factory
{
    private static Dictionary<string, IStrategyShootType> _shootStrategies = new Dictionary<string, IStrategyShootType>();

    public static IStrategyShootType GetShootStrategy(string shootName)
    {
        if (_shootStrategies.ContainsKey(shootName)) return _shootStrategies[shootName];
        else return null;
    }

    public static void AddShootStrategy(string shootName, IStrategyShootType shootStrategy)
    {
        if (!_shootStrategies.ContainsKey(shootName)) _shootStrategies[shootName] = shootStrategy;
    }

    /*public static GameObject SimpleBullet = Resources.Load<GameObject>("Prefabs/Bullet");
    public static GameObject Laser = Resources.Load<GameObject>("Prefabs/Laser");
    public static GameObject Bomb = Resources.Load<GameObject>("Prefabs/Bomb");

    static public GameObject BulletFactory(string type)
    {
        if (type == "Bullet")
        {
            return SimpleBullet;
        }
        else if (type == "Laser")
        {
            return Laser;
        }
        else if (type == "Bomb")
        {
            return Bomb;
        }
        return SimpleBullet;
    }*/
}
