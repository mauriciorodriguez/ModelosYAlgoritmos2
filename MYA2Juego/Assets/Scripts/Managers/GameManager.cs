using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IObserver
{  
    private int _playerLifes;
    private bool _gameOver;
    private Facade _facade;

    private void Awake()
    {
        _facade = new Facade();
        _gameOver = false;

        GameObject.FindGameObjectWithTag(Config.TAG_PLAYER).GetComponent<Player>().AddObserver(this);

        Factory.AddShootStrategy(Config.SHOOT_TYPE_AUTOMATIC, new ShootTypeAutomatic(Config.SHOOT_RATE_AUTOMATIC));
        Factory.AddShootStrategy(Config.SHOOT_TYPE_LASER, new ShootTypeLaser());
        Factory.AddShootStrategy(Config.SHOOT_TYPE_BOMB, new ShootTypeBomb(Config.SHOOT_RATE_BOMB));
    }

    private void Update()
    {
        if (_gameOver && Input.GetKeyDown(KeyCode.Return))
        {
            // TODO : Cambiar reinicializacion de statics
            EnemySpawner.asteroidsCount = Config.ASTEROIDS_COUNT_LEVEL1;
            Asteroid._count = 0;
            SceneManager.LoadScene(0);
        }

        //if (_playerReference.life == 0 && !_gameOver) GameOver("You Lose");
        if (_gameOver) return;
        var asteroids = GameObject.FindGameObjectWithTag(Config.TAG_ENEMIES).GetComponentsInChildren<Asteroid>().Where(a => a.gameObject.activeInHierarchy);
        GameOver(_facade.CheckEndCondition(_playerLifes, asteroids, EnemySpawner.asteroidsCount));
    }

    private void GameOver(string s)
    {
        switch (s)
        {
            case Config.FACADE_MSG_WIN:
                {
                    _gameOver = true;

                }
                break;
            case Config.FACADE_MSG_TIE:
                {
                    _gameOver = true;
                }
                break;
            case Config.FACADE_MSG_LOSE:
                {
                    _gameOver = true;
                }
                break;
            default:
                break;
        }
        GetComponent<UIManager>().GameOver(s);
    }

    public void Notify(GameObject caller, string msg)
    {
        switch (msg)
        {
            case Config.OBSERVER_PLAYER_LIFES:
                _playerLifes = caller.GetComponent<Player>().life;
                break;
            default:
                break;
        }
    }
}
