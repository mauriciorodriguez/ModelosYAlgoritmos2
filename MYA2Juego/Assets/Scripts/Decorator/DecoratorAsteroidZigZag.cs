﻿using UnityEngine;
using System.Collections;
using System;

public class DecoratorAsteroidZigZag : DecoratorAsteroid
{
    private float speed = 50;

    public DecoratorAsteroidZigZag(DecoratorAsteroid nxt = null)
    {
        _nextDeco = nxt;
    }

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
        var xMovement = new Vector3(Mathf.Sin((Time.time/10) * speed), 0, 0);
        go.localPosition = xMovement;
    }
}
