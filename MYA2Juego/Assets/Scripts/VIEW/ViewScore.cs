using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ViewScore : MonoBehaviour, IObserver
{
    public Text scoreText;

    private void Start()
    {
        GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<GameManager>().AddObserverToModel(this);
    }

    public void Notify(Model caller, string msg)
    {
        switch (msg)
        {
            case K.OBSERVER_PLAYER_SCORE:
                scoreText.text = "SCORE: " + caller.score;
                break;
            default:
                break;
        }
    }
}
