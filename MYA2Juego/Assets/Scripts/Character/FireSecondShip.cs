using UnityEngine;
using System.Collections;
using System;

public class FireSecondShip : MonoBehaviour
{

    public string shootType { get; private set; }
    public GameObject _laser;

    public GameObject Master;

    private IStrategyShootType _shootTypeStrategy;
    private PoolManager _poolManagerRef;


    void Start()
    {
        _poolManagerRef = GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>();
        shootType = K.SHOOT_TYPE_AUTOMATIC;
        _shootTypeStrategy = new ShootTypeAutomatic(K.SHOOT_RATE_AUTOMATIC);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space)) Fire();

        else if (Input.GetKey(KeyCode.F)) _laser.SetActive(true);
        else _laser.SetActive(false);

        ShootTypeSelection();
        _shootTypeStrategy.Update();
        //shootType = Master.GetComponent<InputControllerPlayer>().shootType;
    }

    private void ShootTypeSelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            _shootTypeStrategy = null;
            shootType = K.SHOOT_TYPE_AUTOMATIC;
            _shootTypeStrategy = Factory.GetShootStrategy(shootType);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            /*
            _shootTypeStrategy = null;
            shootType = Config.SHOOT_TYPE_LASER;
            _shootTypeStrategy = Factory.GetShootStrategy(shootType);
            */
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            _shootTypeStrategy = null;
            shootType = K.SHOOT_TYPE_BOMB;
            _shootTypeStrategy = Factory.GetShootStrategy(shootType);
        }
    }


    void Fire()
    {

        switch (shootType)
        {
            case K.SHOOT_TYPE_AUTOMATIC:
                _shootTypeStrategy.SpawnBullet(transform, _poolManagerRef.poolBullets);
                break;
            case K.SHOOT_TYPE_LASER:
               // _shootTypeStrategy.SpawnBullet(transform, _poolManagerRef.poolBullets);
                break;
            case K.SHOOT_TYPE_BOMB:
                _shootTypeStrategy.SpawnBullet(transform, _poolManagerRef.poolBombs);
                break;
            default:
                break;
        }

    }


}
