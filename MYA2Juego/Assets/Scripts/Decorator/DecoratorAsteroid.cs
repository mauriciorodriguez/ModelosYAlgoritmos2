using UnityEngine;
using System.Collections;

public abstract class DecoratorAsteroid
{
    protected DecoratorAsteroid _nextDeco;

    public abstract void Execute(Transform go);
    public abstract DecoratorAsteroid Clone();
}
