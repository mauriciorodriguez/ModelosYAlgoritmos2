﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour, IDecoratorProxy, IObserver
{
    public GameObject explosion;

    public DecoratorSecondShip SecondShip;

    public bool WithSecondShip = true;

    void Start()
    {
        SecondShip.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<GameManager>().AddObserverToModel(this);
    }

    /*void OnTriggerEnter2D(Collider2D coll)
    {
        print(coll.gameObject);
        if (coll.gameObject.layer == Config.LAYER_ASTEROID)
        {
            //  Destroy(gameObject);
            Color tmp = _player.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            _player.GetComponent<SpriteRenderer>().color = tmp;
            _player.GetComponent<BoxCollider2D>().enabled = false;

            Instantiate(explosion, transform.position + new Vector3(0, 0, -0.5f), Quaternion.identity);
            life--;

            StartCoroutine(playerSpawn());
            //   Instantiate(_player, transform.position, Quaternion.identity);
        }
    }

    IEnumerator playerSpawn()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == 1)
            {
                Color tmp = _player.GetComponent<SpriteRenderer>().color;
                tmp.a = 1f;
                _player.GetComponent<SpriteRenderer>().color = tmp;
                _player.GetComponent<BoxCollider2D>().enabled = true;
            }
            yield return new WaitForSeconds(1);
        }

    }*/

    public void ExtraShip()
    {
        if (WithSecondShip == true)
        {
            SecondShip.gameObject.SetActive(true);
            SecondShip.flagDestroy = false;
        }
    }

    public void LateUpdate()
    {
        if (SecondShip != null)
        {
            SecondShip.LateUpdate();
        }

    }

    public void DestroyShip()
    {
        if (SecondShip != null)
        {
            SecondShip.DestroyShip();
            SecondShip = null;
        }
        Destroy(gameObject);
        GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<GameManager>().facade.waitSeconds = 0;
    }
    public void Notify(Model caller, string msg)
    {
        switch (msg)
        {
            case K.OBSERVER_PLAYER_ADD_LIVES:
                var tempLives = caller.currentLives;
                var tempMaxLives = caller.maxLives;
                if (tempLives == tempMaxLives) ExtraShip();
                if (tempLives <= 0) DestroyShip();
                break;
            case K.OBSERVER_PLAYER_LIVES:
                var tempCurrentLives = caller.currentLives;
                if (tempCurrentLives <= 0) DestroyShip();
                break;
            default:
                break;
        }
    }
}
