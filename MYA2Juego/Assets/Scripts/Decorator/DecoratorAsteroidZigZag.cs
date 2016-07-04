using UnityEngine;
using System.Collections;
using System;

public class DecoratorAsteroidZigZag : DecoratorAsteroid
{
    public DecoratorAsteroidZigZag(DecoratorAsteroid nxt = null)
    {
        _nextDeco = nxt;
    }

    private float speed = 100;

    public override DecoratorAsteroid Clone()
    {
        DecoratorAsteroid nextClone = null;
        if (_nextDeco != null)
        {
            nextClone = _nextDeco.Clone();
        }
        var thisClone = new DecoratorAsteroidZigZag(nextClone);
        return thisClone;
    }

    public override void Execute(Transform go)
    {
        Move(go);
        if (_nextDeco != null) _nextDeco.Execute(go);
    }

    private void Move(Transform go)
    {
        var xMovement = new Vector3(Mathf.Sin(Time.time * speed), 0, 0);
        go.position += xMovement;
    }
}
