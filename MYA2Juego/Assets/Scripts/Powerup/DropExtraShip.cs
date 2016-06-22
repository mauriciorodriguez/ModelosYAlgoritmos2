using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class DropExtraShip : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("Plack");
        
        if (col.gameObject.layer==Config.LAYER_PLAYER)
        {
            col.GetComponent<Player>().ExtraLife();
            Destroy(this.gameObject);
        }
        
    }
}
