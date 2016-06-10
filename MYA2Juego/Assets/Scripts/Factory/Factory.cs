using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour {

    public static GameObject SimpleBullet=Resources.Load<GameObject>("Prefabs/Bullet");
    public static GameObject Laser = Resources.Load<GameObject>("Prefabs/Laser");
    public static GameObject Bomb = Resources.Load<GameObject>("Prefabs/Bomb");

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    static public GameObject BulletFactory(string type)
    {

        if(type=="Bullet")
        {
            return SimpleBullet;
        }
        else if (type=="Laser")
        {
            return Laser;
        }
        else if (type=="Bomb")
        {
            return Bomb;
        }
        return SimpleBullet;
    }
}
