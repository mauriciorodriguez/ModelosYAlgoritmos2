using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string StartShootType = K.SHOOT_TYPE_AUTOMATIC;
    public string mapName = "MAP 1";
    public int maxLives = K.PLAYER_LIFES;
    public Facade facade { get; private set; }

    private bool _gameOver;
    private Model _model;

    private void Awake()
    {
        _model = new Model(maxLives);
        facade = new Facade();
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
        facade.Update(Time.deltaTime);
        GameOver(facade.CheckEndCondition());
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

    public void AddLivesToModel(int i)
    {
        _model.AddLives(i);
    }

    public void AddScoreToModel(int i)
    {
        _model.AddScore(i);
    }

    public void AddObserverToModel(IObserver o)
    {
        _model.AddObserver(o);
    }

    public void RemoveObserverFromModel(IObserver o)
    {
        _model.RemoveObserver(o);
    }
}
