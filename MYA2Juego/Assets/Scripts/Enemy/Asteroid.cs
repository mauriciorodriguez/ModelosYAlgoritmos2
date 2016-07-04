using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Asteroid : MonoBehaviourCameraBounds, IReusable
{
    public static int _count = 0;

    public float hp, speed;
    public int damage, score;
    public GameObject explosion;
    public bool isOutOfScreen { private set; get; }

    private Vector3 _position, _rotation;
    private DecoratorAsteroid _decorator;
    private ObjectPool<Powerup>[] _poolManagerRef;

    protected override void Start()
    {
        base.Start();
        _poolManagerRef = new ObjectPool<Powerup>[3];
        _poolManagerRef[0] = PoolManager.instance.poolAutomaticPowerUps;
        _poolManagerRef[1] = PoolManager.instance.poolLaserPowerUps;
        _poolManagerRef[2] = PoolManager.instance.poolBombPowerUps;
    }

    public void OnAcquire()
    {
        gameObject.SetActive(true);
    }

    public void OnRelease()
    {
        _decorator = null;
        gameObject.SetActive(false);
    }

    public void OnCreate()
    {
        gameObject.SetActive(false);
        gameObject.name += " : " + (_count++);
    }

    protected override void Update()
    {
        base.Update();
        transform.position += transform.up * speed * Time.deltaTime;
        if (_decorator != null) _decorator.Execute(GetComponentInChildren<SpriteRenderer>().transform);
        CheckHP();
    }

    private void CheckHP()
    {
        if (hp <= 0)
        {
            GameObject.FindGameObjectWithTag(K.TAG_MODEL).GetComponent<Model>().AddScore(score);
            var rnd = UnityEngine.Random.Range(0, 10);
            if (rnd <= 2)
            {
                //print("new");
                //GameObject NewBonus = Instantiate(ExtraLife, transform.position, Quaternion.identity) as GameObject;
                GameObject instance = Instantiate(Resources.Load("Prefabs/NaveBonus", typeof(GameObject))) as GameObject;
                instance.transform.position = transform.position;
            }
            else if (rnd <= 6)
            {
                rnd = UnityEngine.Random.Range(0, 3);
                var go = _poolManagerRef[rnd].GetObject();
                go.transform.position = transform.position;
            }

            switch (gameObject.layer)
            {
                case K.LAYER_SMALL_ASTEROID:
                    PoolManager.instance.poolSmallEnemies.PutBackObject(gameObject);
                    var _exploSmall = Instantiate(explosion, transform.position, Quaternion.identity);
                    Destroy(_exploSmall, 2);
                    break;
                case K.LAYER_MEDIUM_ASTEROID:
                    PoolManager.instance.poolMediumEnemies.PutBackObject(gameObject);
                    var _exploMedium = Instantiate(explosion, transform.position, Quaternion.identity);
                    Destroy(_exploMedium, 2);
                    break;
                case K.LAYER_BIG_ASTEROID:
                    PoolManager.instance.poolBigEnemies.PutBackObject(gameObject);
                    var _exploBig = Instantiate(explosion, transform.position, Quaternion.identity);
                    Destroy(_exploBig, 2);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == K.LAYER_BULLET)
        {
            hp -= col.GetComponent<Ammo>().damage;
            PoolManager.instance.poolBullets.PutBackObject(col.gameObject);
        }
        else if (col.gameObject.layer == K.LAYER_BOMB)
        {
            hp -= col.GetComponent<Ammo>().damage;
            PoolManager.instance.poolBombs.PutBackObject(col.gameObject);
        }
        else if (col.gameObject.layer == K.LAYER_PLAYER)
        {
            GameObject.FindGameObjectWithTag(K.TAG_MODEL).GetComponent<Model>().AddLives(-1);
            hp = 0;
        }
        else if (col.gameObject.tag == K.TAG_ENEMIES)
        {
            transform.up *= -1;
        }

        else if (col.gameObject.layer == K.LAYER_SECOND_SHIP)
        {
            if (col.gameObject.GetComponent<IDecoratorSecondShip>() != null)
            {
                col.gameObject.GetComponent<IDecoratorSecondShip>().DestroyShip();
            }
        }
    }

    public void SetDecorator(DecoratorAsteroid decorator = null)
    {
        _decorator = decorator;
    }

    public GameObject Clone()
    {
        GameObject go;
        switch (gameObject.layer)
        {
            case K.LAYER_SMALL_ASTEROID:
                go = PoolManager.instance.poolSmallEnemies.GetObject();
                break;
            case K.LAYER_MEDIUM_ASTEROID:
                go = PoolManager.instance.poolMediumEnemies.GetObject();
                break;
            case K.LAYER_BIG_ASTEROID:
                go = PoolManager.instance.poolBigEnemies.GetObject();
                break;
            default:
                go = null;
                break;
        }
        if (_decorator != null) go.GetComponent<Asteroid>().SetDecorator(_decorator.Clone());
        return go;
    }
}
