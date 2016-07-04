using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Asteroid : MonoBehaviourCameraBounds, IReusable, IDecoratorAsteroid
{
    public static int _count = 0;

    public float hp, speed;
    public int damage, score;
    public GameObject explosion;
    public bool isOutOfScreen { private set; get; }

    private Vector3 _position, _rotation;
    private IDecoratorAsteroid _decorator;

    public void OnAcquire()
    {
        gameObject.SetActive(true);
    }

    public void OnRelease()
    {
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
        Execute(gameObject);
        if (_decorator != null) _decorator.Execute(gameObject);
        CheckHP();
    }

    private void CheckHP()
    {
        if (hp <= 0)
        {
            GameObject.FindGameObjectWithTag(K.TAG_MODEL).GetComponent<Model>().AddScore(score);
            if (UnityEngine.Random.Range(0, 5) > 2)
            {
                //print("new");
                //GameObject NewBonus = Instantiate(ExtraLife, transform.position, Quaternion.identity) as GameObject;
                GameObject instance = Instantiate(Resources.Load("Prefabs/NaveBonus", typeof(GameObject))) as GameObject;
                instance.transform.position = transform.position;
            }

            switch (gameObject.layer)
            {
                case K.LAYER_SMALL_ASTEROID:
                    GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolSmallEnemies.PutBackObject(gameObject);
                    var _exploSmall = Instantiate(explosion, transform.position, Quaternion.identity);
                    Destroy(_exploSmall, 2);
                    break;
                case K.LAYER_MEDIUM_ASTEROID:
                    GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolMediumEnemies.PutBackObject(gameObject);
                    var _exploMedium = Instantiate(explosion, transform.position, Quaternion.identity);
                    Destroy(_exploMedium, 2);
                    break;
                case K.LAYER_BIG_ASTEROID:
                    GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolBigEnemies.PutBackObject(gameObject);
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
            GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolBullets.PutBackObject(col.gameObject);
        }
        else if (col.gameObject.layer == K.LAYER_BOMB)
        {
            hp -= col.GetComponent<Ammo>().damage;
            GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolBombs.PutBackObject(col.gameObject);
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
            if(col.gameObject.GetComponent<IDecoratorSecondShip>() != null)
            {
                col.gameObject.GetComponent<IDecoratorSecondShip>().DestroyShip();
            }
        }
    }

    public void SetDecorator(IDecoratorAsteroid decorator)
    {
        _decorator = decorator;
    }

    public void Execute(GameObject go)
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
