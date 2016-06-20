using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private Player _playerReference;
    public Text youWinText;
    public Text tieText;
    public Text youLoseText;
    public Text restartText;
    private bool _gameOver;
    private void Awake()
    {
        _playerReference = GameObject.FindGameObjectWithTag(Config.TAG_PLAYER).GetComponent<Player>();
        Factory.AddShootStrategy(Config.SHOOT_TYPE_AUTOMATIC, new ShootTypeAutomatic(Config.SHOOT_RATE_AUTOMATIC));
        Factory.AddShootStrategy(Config.SHOOT_TYPE_LASER, new ShootTypeLaser());
        Factory.AddShootStrategy(Config.SHOOT_TYPE_BOMB, new ShootTypeBomb(Config.SHOOT_RATE_BOMB));
        _gameOver = false;
    }

    private void Update()
    {
        if (_gameOver && Input.GetKeyDown(KeyCode.Return)) ScreenManager.instance.PopScreen();

        if (_playerReference.life == 0 && !_gameOver) GameOver("You Lose");
    }

    private void GameOver(string s)
    {
        print(s);
        switch (s)
        {
            case "You Win":
            {
                youWinText.gameObject.SetActive(true);
                _gameOver = true;

            }
                break;
            case "TIE":
            {
                tieText.gameObject.SetActive(true);
                _gameOver = true;
            }
                break;
            case "You Lose":
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
