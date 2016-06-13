using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    private Player _playerReference;

    private void Awake()
    {
        _playerReference = GameObject.FindGameObjectWithTag(K.TAG_PLAYER).GetComponent<Player>();
    }
}
