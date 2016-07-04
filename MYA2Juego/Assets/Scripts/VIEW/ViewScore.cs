using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ViewScore : MonoBehaviour, IObserver
{
    public Text scoreText;

    private void Start()
    {
        GameObject.FindGameObjectWithTag(K.TAG_MODEL).GetComponent<Model>().AddObserver(this);
    }

    public void Notify(GameObject caller, string msg)
    {
        switch (msg)
        {
            case K.OBSERVER_PLAYER_SCORE:
                scoreText.text = "SCORE: " + caller.GetComponent<Model>().score;
                break;
            default:
                break;
        }
    }
}
