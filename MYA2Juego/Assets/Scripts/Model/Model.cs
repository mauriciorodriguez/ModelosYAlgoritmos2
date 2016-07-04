using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Model : IObservable
{
    public int maxLives { get; private set; }
    public int currentLives { get; private set; }
    public int score { get; private set; }

    private List<IObserver> _obs;

    public Model(int maxLives)
    {
        _obs = new List<IObserver>();
        this.maxLives = maxLives;
        currentLives = maxLives;
    }

    public void AddObserver(IObserver obs)
    {
        if (!_obs.Contains(obs)) _obs.Add(obs);
        Notify(K.OBSERVER_PLAYER_LIVES);
        Notify(K.OBSERVER_PLAYER_SCORE);
    }

    public void RemoveObserver(IObserver obs)
    {
        if (_obs.Contains(obs)) _obs.Remove(obs);
    }

    public void Notify(string msg)
    {
        foreach (var o in _obs) o.Notify(this, msg);
    }

    public void AddLives(int i)
    {
        bool isAddingExtraShip = false;
        if (currentLives == maxLives) isAddingExtraShip = true;
        if (currentLives < maxLives || i < 0) currentLives += i;
        if (isAddingExtraShip) Notify(K.OBSERVER_PLAYER_ADD_LIVES);
        else Notify(K.OBSERVER_PLAYER_LIVES);
    }

    public void AddScore(int s)
    {
        score += s;
        Notify(K.OBSERVER_PLAYER_SCORE);
    }
}
