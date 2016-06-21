using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Facade
{
    public string CheckEndCondition(Player player, IEnumerable<Asteroid> asteroids, int asteroidCountPerLevel)
    {
        if (player.life <= 0 && asteroids.Count() == 0 && asteroidCountPerLevel == 0)
        {
            return Config.FACADE_MSG_TIE;
        }
        else if (player.life <= 0)
        {
            return Config.FACADE_MSG_LOSE;
        }
        else if (asteroids.Count() == 0 && asteroidCountPerLevel == 0)
        {
            return Config.FACADE_MSG_WIN;
        }
        return Config.FACADE_MSG_CONTROL;
    }
}
