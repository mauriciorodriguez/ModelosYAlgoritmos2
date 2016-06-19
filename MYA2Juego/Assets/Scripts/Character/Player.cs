using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public GameObject explosion;
    public float life;

    private GameObject _player;
    private 

    void Awake()
    {
        _player = this.gameObject;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == Config.LAYER_ASTEROID)
        {
          //  Destroy(gameObject);
             Color tmp = _player.GetComponent<SpriteRenderer>().color;
             tmp.a = 0f;
             _player.GetComponent<SpriteRenderer>().color = tmp;
             _player.GetComponent<BoxCollider2D>().enabled = false;

             Instantiate(explosion, transform.position + new Vector3(0,0,-0.5f), Quaternion.identity);
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

    }
}
