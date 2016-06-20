using UnityEngine;
using System.Collections;
using System;

public class DecoratorAsteroidZigZag : IDecoratorAsteroid
{
    private float speed = 100;
    private IDecoratorAsteroid _decorator;

    public void Execute(GameObject go)
    {
        Move(go);
        if (_decorator != null) _decorator.Execute(go);
    }

    private void Move(GameObject go)
    {
        // TODO : Checkear formula
        var xMovement = new Vector3(Mathf.Sin(Time.time * speed), 0, 0);
        go.transform.position += xMovement;
    }

    public void SetDecorator(IDecoratorAsteroid decorator)
    {
        _decorator = decorator;
    }
}
