using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Asteroid : MonoBehaviour, IReusable, IDecoratorAsteroid, IObservable
{
    public static int _count = 0;

    public float hp, speed;
    public int damage, score;
    public GameObject explosion;
    public bool isOutOfScreen { private set; get; }

    private Vector3 _position, _rotation;
    private SpriteRenderer _model;
    private IDecoratorAsteroid _decorator;
    private List<IObserver> _obs;

    private void Start()
    {
        _model = GetComponent<SpriteRenderer>();
    }

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

    private void Update()
    {
        Execute(gameObject);
        if (_decorator != null) _decorator.Execute(gameObject);
        CheckScreenBorder();
        CheckHP();
    }

    private void CheckHP()
    {
        if (hp <= 0)
        {
            if (UnityEngine.Random.Range(0, 5) > 2)
            {
                //print("new");
                //GameObject NewBonus = Instantiate(ExtraLife, transform.position, Quaternion.identity) as GameObject;
                GameObject instance = Instantiate(Resources.Load("Prefabs/NaveBonus", typeof(GameObject))) as GameObject;
                instance.transform.position = transform.position;

            }

            var player = GameObject.FindGameObjectWithTag(Config.TAG_PLAYER).GetComponent<Player>();
            player.score += score;
            player.Notify(Config.OBSERVER_PLAYER_SCORE);
            switch (gameObject.layer)
            {
                case Config.LAYER_SMALL_ASTEROID:
                    GameObject.FindGameObjectWithTag(Config.TAG_MANAGERS).GetComponent<PoolManager>().poolSmallEnemies.PutBackObject(gameObject);
                    var _exploSmall = Instantiate(explosion, transform.position, Quaternion.identity);
                    Destroy(_exploSmall, 2);
                    break;
                case Config.LAYER_MEDIUM_ASTEROID:
                    GameObject.FindGameObjectWithTag(Config.TAG_MANAGERS).GetComponent<PoolManager>().poolMediumEnemies.PutBackObject(gameObject);
                    var _exploMedium = Instantiate(explosion, transform.position, Quaternion.identity);
                    Destroy(_exploMedium, 2);
                    break;
                case Config.LAYER_BIG_ASTEROID:
                    GameObject.FindGameObjectWithTag(Config.TAG_MANAGERS).GetComponent<PoolManager>().poolBigEnemies.PutBackObject(gameObject);
                    var _exploBig = Instantiate(explosion, transform.position, Quaternion.identity);
                    Destroy(_exploBig, 2);
                    break;
                default:
                    break;
            }
        }
    }

    private void CheckScreenBorder()
    {
        //Screen Limits
        float cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;

        if (transform.position.y - _model.bounds.size.y / 2 > Camera.main.orthographicSize)
            transform.position = new Vector2(transform.position.x, -Camera.main.orthographicSize - _model.bounds.size.y / 2);

        else if (transform.position.y + _model.bounds.size.y / 2 < -Camera.main.orthographicSize)
            transform.position = new Vector2(transform.position.x, Camera.main.orthographicSize + _model.bounds.size.y / 2);

        if (transform.position.x - _model.bounds.size.x / 2 > cameraWidth)
            transform.position = new Vector2(-cameraWidth - _model.bounds.size.x / 2, transform.position.y);

        else if (transform.position.x + _model.bounds.size.x / 2 < -cameraWidth)
            transform.position = new Vector2(cameraWidth + _model.bounds.size.x / 2, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == Config.LAYER_BULLET)
        {
            hp -= col.GetComponent<Ammo>().damage;
            GameObject.FindGameObjectWithTag(Config.TAG_MANAGERS).GetComponent<PoolManager>().poolBullets.PutBackObject(col.gameObject);
        }
        else if (col.gameObject.layer == Config.LAYER_BOMB)
        {
            hp -= col.GetComponent<Ammo>().damage;
            GameObject.FindGameObjectWithTag(Config.TAG_MANAGERS).GetComponent<PoolManager>().poolBombs.PutBackObject(col.gameObject);
        }
        else if (col.gameObject.layer == Config.LAYER_PLAYER)
        {
            col.GetComponent<Player>().SetLife(damage);

            switch (gameObject.layer)
            {
                case Config.LAYER_SMALL_ASTEROID:
                    GameObject.FindGameObjectWithTag(Config.TAG_MANAGERS).GetComponent<PoolManager>().poolSmallEnemies.PutBackObject(gameObject);
                    break;
                case Config.LAYER_MEDIUM_ASTEROID:
                    GameObject.FindGameObjectWithTag(Config.TAG_MANAGERS).GetComponent<PoolManager>().poolMediumEnemies.PutBackObject(gameObject);
                    break;
                case Config.LAYER_BIG_ASTEROID:
                    GameObject.FindGameObjectWithTag(Config.TAG_MANAGERS).GetComponent<PoolManager>().poolBigEnemies.PutBackObject(gameObject);
                    break;
                default:
                    break;
            }
        }
        else if (col.gameObject.tag == Config.TAG_ENEMIES)
        {
            transform.up *= -1;
        }

        else if (col.gameObject.layer == Config.LAYER_SECOND_SHIP)
        {
            if(col.gameObject.GetComponent<IDecoratorSecondShip>() != null)
            {
                col.gameObject.GetComponent<IDecoratorSecondShip>().Destroy();
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

    public void AddObserver(IObserver obs)
    {
        if (!_obs.Contains(obs)) _obs.Add(obs);
    }

    public void RemoveObserver(IObserver obs)
    {
        if (_obs.Contains(obs)) _obs.Remove(obs);
    }

    public void Notify(string msg)
    {
        foreach (var o in _obs)
        {
            o.Notify(gameObject, msg);
        }
    }
}
