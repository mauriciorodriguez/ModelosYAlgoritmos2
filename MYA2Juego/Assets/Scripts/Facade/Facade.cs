using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Facade : IObserver
{
    public float waitSeconds;
    private int _playerLifes, _asteroidCountPerLevel;
    private IEnumerable<Asteroid> _activeAsteroids;
    private GameObject _asteroidsContainer;

    public Facade()
    {
        GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<GameManager>().AddObserverToModel(this);
        _asteroidsContainer = GameObject.FindGameObjectWithTag(K.TAG_ENEMIES);
    }

    public string CheckEndCondition()
    {
        if (waitSeconds > 2)
        {
            _asteroidCountPerLevel = EnemySpawner.asteroidsCount;
            _activeAsteroids = _asteroidsContainer.GetComponentsInChildren<Asteroid>().Where(a => a.gameObject.activeInHierarchy);
            if (_playerLifes <= 0 && _activeAsteroids.Count() == 0 && _asteroidCountPerLevel == 0)
            {
                return K.FACADE_MSG_TIE;
            }
            else if (_playerLifes <= 0)
            {
                return K.FACADE_MSG_LOSE;
            }
            else if (_activeAsteroids.Count() == 0 && _asteroidCountPerLevel == 0)
            {
                return K.FACADE_MSG_WIN;
            }
        }        
        return K.FACADE_MSG_CONTROL;
    }

    public void Update(float deltaTime)
    {        
        waitSeconds += deltaTime;
    }

    public void Notify(Model caller, string msg)
    {
        switch (msg)
        {
            case K.OBSERVER_PLAYER_LIVES:
                _playerLifes = caller.currentLives;
                break;
            default:
                break;
        }
    }
}
