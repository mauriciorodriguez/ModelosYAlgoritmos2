using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class DropExtraShip : MonoBehaviour
{
    public float lifeTime;
    private GameManager _gameManagerRef;

    private void Start()
    {
        _gameManagerRef = GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == K.LAYER_PLAYER)
        {
            print("Life picked up");
            _gameManagerRef.AddLivesToModel(1);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime<=0)
        {
            Destroy(gameObject);
        }
    }
}
