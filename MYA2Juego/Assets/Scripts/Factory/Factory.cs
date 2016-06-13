using UnityEngine;
using System.Collections;

public class Factory
{
    public static GameObject SimpleBullet = Resources.Load<GameObject>("Prefabs/Bullet");
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
    }
}
