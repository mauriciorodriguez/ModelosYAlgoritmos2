using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Facade
{
    public string CheckEndCondition(int playerLifes, IEnumerable<Asteroid> asteroids, int asteroidCountPerLevel)
    {
        if (playerLifes <= 0 && asteroids.Count() == 0 && asteroidCountPerLevel == 0)
        {
            return Config.FACADE_MSG_TIE;
        }
        else if (playerLifes <= 0)
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
