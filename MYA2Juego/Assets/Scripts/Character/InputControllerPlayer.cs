using UnityEngine;
using System.Collections;
using System;

public class InputControllerPlayer : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public string shootType { get; private set; }
    public string powerupType;
    public GameObject _laser;

    private Vector3 rotationVector;
    private SpriteRenderer _model;
    private IStrategyShootType _shootTypeStrategy;
    private PoolManager _poolManagerRef;

    private float timer = 5f;

    public bool powerupAutomatic;
    public bool powerupLaser;
    public bool powerupBomb;
    void Start()
    {
        _poolManagerRef = GameObject.FindGameObjectWithTag(Config.TAG_MANAGERS).GetComponent<PoolManager>();
        _model = transform.GetComponent<SpriteRenderer>();
        shootType = Config.SHOOT_TYPE_AUTOMATIC;
        powerupType = "";
        _shootTypeStrategy = new ShootTypeAutomatic(Config.SHOOT_RATE_AUTOMATIC);
        //Luego tienen que instanciarse en un pool
    }

    void Update()
    {
        //Movements     
        transform.position += Input.GetAxis(Config.INPUT_VERTICAL) * speed * transform.up * Time.deltaTime;
        rotationVector.z = rotationSpeed * -Input.GetAxis(Config.INPUT_HORIZONTAL);
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
        else _laser.SetActive(false);

        ShootTypeSelection();
        _shootTypeStrategy.Update();
        CheckPowerup();
    }

    private void ShootTypeSelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            _shootTypeStrategy = null;
            shootType = Config.SHOOT_TYPE_AUTOMATIC;
            _shootTypeStrategy = Factory.GetShootStrategy(shootType);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            _shootTypeStrategy = null;
            shootType = Config.SHOOT_TYPE_LASER;
            _shootTypeStrategy = Factory.GetShootStrategy(shootType);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            _shootTypeStrategy = null;
            shootType = Config.SHOOT_TYPE_BOMB;
            _shootTypeStrategy = Factory.GetShootStrategy(shootType);
        }
    }

    private void CheckPowerup()
    {
        if (_laser.activeSelf && shootType == Config.POWERUP_TYPE_LASER)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                _laser.GetComponent<Laser>().DisablePowerup();
                powerupType = "";
                shootType = Config.SHOOT_TYPE_LASER;
                timer = 5;
            }
        }

        else if(shootType == Config.POWERUP_TYPE_BOMB)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                powerupType = "";
                shootType = Config.SHOOT_TYPE_BOMB;
                timer = 5;
                print("termino");
            }
        }

    }

    void Fire()
    {
        //Por ahora solo dispara Simple Bullets
        /*GameObject newBullet;
        newBullet=Instantiate<GameObject>(Factory.BulletFactory("Bullet"));
        newBullet.transform.position = transform.position;*/

        if (powerupType != "") shootType = powerupType;

        switch (shootType)
        {
            case Config.SHOOT_TYPE_AUTOMATIC:
                _shootTypeStrategy.SpawnBullet(transform, _poolManagerRef.poolBullets);
                break;
            case Config.SHOOT_TYPE_LASER:
                _laser.SetActive(true);
                break;
            case Config.SHOOT_TYPE_BOMB:
                _shootTypeStrategy.SpawnBullet(transform, _poolManagerRef.poolBombs);
                break;
            case Config.POWERUP_TYPE_AUTOMATIC:
                _shootTypeStrategy.SpawnBullet(transform, _poolManagerRef.poolBullets);
                break;
            case Config.POWERUP_TYPE_LASER:
                _laser.SetActive(true);
                if (powerupType != "") _laser.GetComponent<Laser>().EnablePowerup();
                break;
            case Config.POWERUP_TYPE_BOMB:
                if (powerupType != "") _shootTypeStrategy.SpawnBullet(transform, _poolManagerRef.poolSuperBombs);
                break;
            default:
                break;
        }

    }
}
