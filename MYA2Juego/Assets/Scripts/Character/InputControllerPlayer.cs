using UnityEngine;
using System.Collections;
using System;

public class InputControllerPlayer : MonoBehaviourCameraBounds
{
    public float speed;
    public float rotationSpeed;
    public string shootType { get; private set; }
    public GameObject _laser;

    private Vector3 rotationVector;
    private IStrategyShootType _shootTypeStrategy;

    protected override void Start()
    {
        base.Start();

        shootType = GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<GameManager>().StartShootType;
        _shootTypeStrategy = Factory.GetShootStrategy(shootType);
    }

    protected override void Update()
    {
        base.Update();
        //Movements     
        transform.position += Input.GetAxis(K.INPUT_VERTICAL) * speed * transform.up * Time.deltaTime;
        rotationVector.z = rotationSpeed * -Input.GetAxis(K.INPUT_HORIZONTAL);
        transform.Rotate(rotationVector * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space)) Fire();
        else _laser.SetActive(false);

        _shootTypeStrategy.Update();
    }

    public void PowerupGrab(string name)
    {
        shootType = name;
        _shootTypeStrategy = Factory.GetShootStrategy(shootType);
    }

    void Fire()
    {
        switch (shootType)
        {
            case K.SHOOT_TYPE_AUTOMATIC:
                _shootTypeStrategy.SpawnBullet(transform, PoolManager.instance.poolBullets);
                break;
            case K.SHOOT_TYPE_LASER:
                _laser.SetActive(true);
                break;
            case K.SHOOT_TYPE_BOMB:
                _shootTypeStrategy.SpawnBullet(transform, PoolManager.instance.poolBombs);
                break;
            default:
                break;
        }

    }
}
