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
        if(coll.gameObject.layer == Config.LAYER_PLAYER)
        {
            var player = coll.gameObject.GetComponent<InputControllerPlayer>();

            if (player.shootType == Config.SHOOT_TYPE_AUTOMATIC) player.powerupType = Config.POWERUP_TYPE_AUTOMATIC;
            else if (player.shootType == Config.SHOOT_TYPE_LASER) player.powerupType = Config.POWERUP_TYPE_LASER;
            else player.powerupType = Config.POWERUP_TYPE_BOMB;
            Destroy(this.gameObject);
        }
    }
}
