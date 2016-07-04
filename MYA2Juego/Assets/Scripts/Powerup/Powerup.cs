using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Powerup : MonoBehaviour
{
    void Start ()
    {
	}
	
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.layer == K.LAYER_PLAYER)
        {
            var player = coll.gameObject.GetComponent<InputControllerPlayer>();

            if (player.shootType == K.SHOOT_TYPE_AUTOMATIC) player.powerupType = K.POWERUP_TYPE_AUTOMATIC;
            else if (player.shootType == K.SHOOT_TYPE_LASER) player.powerupType = K.POWERUP_TYPE_LASER;
            else player.powerupType = K.POWERUP_TYPE_BOMB;
            Destroy(this.gameObject);
        }
    }
}
