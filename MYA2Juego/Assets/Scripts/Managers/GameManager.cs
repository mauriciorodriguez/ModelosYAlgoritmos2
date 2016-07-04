using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Model model;
    public string StartShootType = K.SHOOT_TYPE_AUTOMATIC;
    public string mapName = "MAP 1";

    private bool _gameOver;
    private Facade _facade;

    private void Awake()
    {
        _facade = new Facade();
        _gameOver = false;
        print("Start Shoot Type: " + StartShootType);
        print("Map name: " + mapName);

        Factory.AddShootStrategy(K.SHOOT_TYPE_AUTOMATIC, new ShootTypeAutomatic(K.SHOOT_RATE_AUTOMATIC));
        Factory.AddShootStrategy(K.SHOOT_TYPE_LASER, new ShootTypeLaser());
        Factory.AddShootStrategy(K.SHOOT_TYPE_BOMB, new ShootTypeBomb(K.SHOOT_RATE_BOMB));
    }

    private void Update()
    {
        if (_gameOver && Input.GetKeyDown(KeyCode.Return))
        {
            EnemySpawner.asteroidsCount = K.ASTEROIDS_COUNT_LEVEL1;
            Asteroid._count = 0;
            ScreenManager.instance.PopScreen();
        }
        if (_gameOver) return;
        //var asteroids = GameObject.FindGameObjectWithTag(K.TAG_ENEMIES).GetComponentsInChildren<Asteroid>().Where(a => a.gameObject.activeInHierarchy);
        //GameOver(_facade.CheckEndCondition(_playerLifes, asteroids, EnemySpawner.asteroidsCount));
    }

    private void GameOver(string s)
    {
        switch (s)
        {
            case K.FACADE_MSG_WIN:
                {
                    _gameOver = true;

                }
                break;
            case K.FACADE_MSG_TIE:
                {
                    _gameOver = true;
                }
                break;
            case K.FACADE_MSG_LOSE:
                {
                    _gameOver = true;
                }
                break;
            default:
                break;
        }
        GetComponent<UIManager>().GameOver(s);
    }
}
