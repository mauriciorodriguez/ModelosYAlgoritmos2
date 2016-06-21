using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class UIManager : MonoBehaviour, IObserver
{
    public Text youWinText, tieText, youLoseText, restartText, scoreText;
    public GameObject LifePrefab;

    private int _playerLifes;
    private List<GameObject> _lifesPrefabs;

    private void Awake()
    {
        _lifesPrefabs = new List<GameObject>();
        GameObject.FindGameObjectWithTag(Config.TAG_PLAYER).GetComponent<Player>().AddObserver(this);
    }

    public void Notify(GameObject caller, string msg)
    {
        switch (msg)
        {
            case Config.OBSERVER_PLAYER_LIFES:
                _playerLifes = caller.GetComponent<Player>().life;
                UpdateLifes();
                break;
            case Config.OBSERVER_PLAYER_SCORE:
                UpdateScore(caller.GetComponent<Player>().score);
                break;
            default:
                break;
        }
    }

    public void GameOver(string s)
    {
        switch (s)
        {
            case Config.FACADE_MSG_WIN:
                {
                    youWinText.gameObject.SetActive(true);

                }
                break;
            case Config.FACADE_MSG_TIE:
                {
                    tieText.gameObject.SetActive(true);
                }
                break;
            case Config.FACADE_MSG_LOSE:
                {
                    youLoseText.gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }
        if (s != Config.FACADE_MSG_CONTROL)
        {
            restartText.gameObject.SetActive(true);
        }
    }

    private void UpdateScore(int score)
    {
        scoreText.text = "SCORE: " + score;
    }

    private void UpdateLifes()
    {
        foreach (var life in _lifesPrefabs)
        {
            Destroy(life);
        }
        for (int i = 0; i < _playerLifes; i++)
        {
            var go = Instantiate(LifePrefab);
            go.transform.SetParent(GameObject.FindGameObjectWithTag(Config.TAG_LIFES).transform);
            Vector3 aux = new Vector3(-860 + i * 100, 420, 0);
            go.transform.localScale = Vector3.one;
            go.GetComponent<RectTransform>().localPosition = aux;
            _lifesPrefabs.Add(go);
        }
    }
}
