using UnityEngine;
using System.Collections;
using System;

public class Asteroid : MonoBehaviour, IReusable
{
    public static int _count = 0;
    public float hp, speed;
    public bool isOutOfScreen { private set; get; }

    private Vector3 _position, _rotation;
    private SpriteRenderer _model;

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
        gameObject.transform.parent = GameObject.FindGameObjectWithTag(K.TAG_ENEMIES).transform;
        gameObject.SetActive(false);
        gameObject.name += " : " + (_count++);
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        if (hp <= 0)
        {
            switch (gameObject.layer)
            {
                case K.LAYER_SMALL_ASTEROID:
                    GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolSmallEnemies.PutBackObject(gameObject);
                    break;
                case K.LAYER_MEDIUM_ASTEROID:
                    GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolMediumEnemies.PutBackObject(gameObject);
                    break;
                case K.LAYER_BIG_ASTEROID:
                    GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolBigEnemies.PutBackObject(gameObject);
                    break;
                default:
                    break;
            }
        }

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
        if (col.gameObject.layer == K.LAYER_BULLET)
        {
            hp -= col.GetComponent<Ammo>().damage;
            GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolBullets.PutBackObject(col.gameObject);
        }
        else if (col.gameObject.tag == K.TAG_ENEMIES)
        {
            transform.up *= -1;
        }
    }
}
