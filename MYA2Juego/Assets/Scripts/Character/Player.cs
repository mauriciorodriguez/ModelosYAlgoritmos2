using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public GameObject explosion;
    public int life;

    private GameObject _player;
    public List<GameObject> lifesIcon;

    void Awake()
    {
        _player = this.gameObject;
        life = Config.PLAYER_LIFES;
    }

    public void SetLife(int dmg)
    {
        if (life > 0)
        {
            lifesIcon[life - 1].gameObject.SetActive(false);
            life -= dmg;
        }
        if(life == 0) Destroy(this.gameObject);
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
