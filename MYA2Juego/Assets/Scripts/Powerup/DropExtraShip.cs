using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class DropExtraShip : MonoBehaviour
{
    private Model _model;

    private void Start()
    {
        _model = GameObject.FindGameObjectWithTag(K.TAG_MODEL).GetComponent<Model>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == K.LAYER_PLAYER)
        {
            _model.AddLives(1);
            Destroy(gameObject);
        }

    }
}
