using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour, IObservable
{
    public GameObject explosion;
    public int life;

    private GameObject _player;
    private List<IObserver> _obs = new List<IObserver>();

    void Start()
    {
        _player = gameObject;
        Notify(Config.OBSERVER_PLAYER_LIFES);
    }

    public void SetLife(int dmg)
    {
        life -= dmg;
        Notify(Config.OBSERVER_PLAYER_LIFES);
        if (life == 0) Destroy(this.gameObject);
    }

    public void AddObserver(IObserver obs)
    {
        if (!_obs.Contains(obs)) _obs.Add(obs);
    }

    public void RemoveObserver(IObserver obs)
    {
        if (_obs.Contains(obs)) _obs.Remove(obs);
    }

    public void Notify(string msg)
    {
        foreach (var o in _obs)
        {
            o.Notify(gameObject, msg);
        }
    }

    /*void OnTriggerEnter2D(Collider2D coll)
    {
        print(coll.gameObject);
        if (coll.gameObject.layer == Config.LAYER_ASTEROID)
        {
            //  Destroy(gameObject);
            Color tmp = _player.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            _player.GetComponent<SpriteRenderer>().color = tmp;
            _player.GetComponent<BoxCollider2D>().enabled = false;

            Instantiate(explosion, transform.position + new Vector3(0, 0, -0.5f), Quaternion.identity);
            life--;

            StartCoroutine(playerSpawn());
            //   Instantiate(_player, transform.position, Quaternion.identity);
        }
    }

    IEnumerator playerSpawn()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == 1)
            {
                Color tmp = _player.GetComponent<SpriteRenderer>().color;
                tmp.a = 1f;
                _player.GetComponent<SpriteRenderer>().color = tmp;
                _player.GetComponent<BoxCollider2D>().enabled = true;
            }
            yield return new WaitForSeconds(1);
        }

    }*/
}
