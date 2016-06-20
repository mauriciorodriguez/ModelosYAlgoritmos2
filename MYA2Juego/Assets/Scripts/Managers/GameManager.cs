using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private Player _playerReference;

    private void Awake()
    {
        _playerReference = GameObject.FindGameObjectWithTag(Config.TAG_PLAYER).GetComponent<Player>();
        Factory.AddShootStrategy(Config.SHOOT_TYPE_AUTOMATIC, new ShootTypeAutomatic(Config.SHOOT_RATE_AUTOMATIC));
        Factory.AddShootStrategy(Config.SHOOT_TYPE_LASER, new ShootTypeLaser());
        Factory.AddShootStrategy(Config.SHOOT_TYPE_BOMB, new ShootTypeBomb(Config.SHOOT_RATE_BOMB));
    }

    private void Update()
    {

    }
}
