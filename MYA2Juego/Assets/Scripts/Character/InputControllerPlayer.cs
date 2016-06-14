using UnityEngine;
using System.Collections;
using System;

public class InputControllerPlayer : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public string shootType { get; private set; }
    public GameObject _laser;

    private Vector3 rotationVector;
    private SpriteRenderer _model;
    private IStrategyShootType _shootTypeStrategy;
    private PoolManager _poolManagerRef;

    void Start()
    {
        _poolManagerRef = GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>();
        _model = transform.GetComponent<SpriteRenderer>();
        shootType = K.SHOOT_TYPE_AUTOMATIC;
        _shootTypeStrategy = new ShootTypeAutomatic(K.SHOOT_RATE_AUTOMATIC);
        //Luego tienen que instanciarse en un pool
    }

    void Update()
    {
        //Movements     
        transform.position += Input.GetAxis(K.INPUT_VERTICAL) * speed * transform.up * Time.deltaTime;
        rotationVector.z = rotationSpeed * -Input.GetAxis(K.INPUT_HORIZONTAL);
        transform.Rotate(rotationVector * Time.deltaTime);


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

        if (Input.GetKey(KeyCode.Space)) Fire();
        else if (Input.GetKey(KeyCode.F)) _laser.SetActive(true);
        else _laser.SetActive(false);

        ShootTypeSelection();
        _shootTypeStrategy.Update();
    }

    private void ShootTypeSelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            shootType = K.SHOOT_TYPE_AUTOMATIC;
            _shootTypeStrategy = new ShootTypeAutomatic(K.SHOOT_RATE_AUTOMATIC);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            _shootTypeStrategy = new ShootTypeLaser();
            shootType = K.SHOOT_TYPE_LASER;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            shootType = K.SHOOT_TYPE_BOMB;
            _shootTypeStrategy = new ShootTypeBomb(K.SHOOT_RATE_BOMB);
        }
    }

    void Fire()
    {
        //Por ahora solo dispara Simple Bullets
        /*GameObject newBullet;
        newBullet=Instantiate<GameObject>(Factory.BulletFactory("Bullet"));
        newBullet.transform.position = transform.position;*/
        switch (shootType)
        {
            case K.SHOOT_TYPE_AUTOMATIC:
                _shootTypeStrategy.SpawnBullet(transform, _poolManagerRef.poolBullets);
                break;
            case K.SHOOT_TYPE_LASER:
                _shootTypeStrategy.SpawnBullet(transform, _poolManagerRef.poolBullets);
                break;
            case K.SHOOT_TYPE_BOMB:
                _shootTypeStrategy.SpawnBullet(transform, _poolManagerRef.poolBombs);
                break;
            default:
                break;
        }

    }
}
