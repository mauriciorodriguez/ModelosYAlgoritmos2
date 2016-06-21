using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Text youWinText;
    public Text tieText;
    public Text youLoseText;
    public Text restartText;

    private Player _playerReference;
    private bool _gameOver;
    private Facade _facade;

    private void Awake()
    {
        _facade = new Facade();
        _playerReference = GameObject.FindGameObjectWithTag(Config.TAG_PLAYER).GetComponent<Player>();
        Factory.AddShootStrategy(Config.SHOOT_TYPE_AUTOMATIC, new ShootTypeAutomatic(Config.SHOOT_RATE_AUTOMATIC));
        Factory.AddShootStrategy(Config.SHOOT_TYPE_LASER, new ShootTypeLaser());
        Factory.AddShootStrategy(Config.SHOOT_TYPE_BOMB, new ShootTypeBomb(Config.SHOOT_RATE_BOMB));
        _gameOver = false;
    }

    private void Update()
    {
        if (_gameOver && Input.GetKeyDown(KeyCode.Return)) ScreenManager.instance.PopScreen();

        //if (_playerReference.life == 0 && !_gameOver) GameOver("You Lose");
        if (_gameOver) return;
        var asteroids = GameObject.FindGameObjectWithTag(Config.TAG_ENEMIES).GetComponentsInChildren<Asteroid>().Where(a => a.gameObject.activeInHierarchy);
        GameOver(_facade.CheckEndCondition(_playerReference, asteroids, EnemySpawner.asteroidsCount));
    }

    private void GameOver(string s)
    {
        switch (s)
        {
            case Config.FACADE_MSG_WIN:
                {
                    youWinText.gameObject.SetActive(true);
                    _gameOver = true;

                }
                break;
            case Config.FACADE_MSG_TIE:
                {
                    tieText.gameObject.SetActive(true);
                    _gameOver = true;
                }
                break;
            case Config.FACADE_MSG_LOSE:
                {
                    youLoseText.gameObject.SetActive(true);
                    _gameOver = true;
                }
                break;
            default:
                break;
        }
        restartText.gameObject.SetActive(true);
    }
}
