using UnityEngine;
using System.Collections;

public class DecoratorAsteroidRotate : DecoratorAsteroid
{
    private float _speed = 5;

    public DecoratorAsteroidRotate(DecoratorAsteroid nxt = null)
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
        var thisClone = new DecoratorAsteroidRotate(nextClone);
        return thisClone;
    }

    public override void Execute(Transform go)
    {
        Move(go);
        if (_nextDeco != null) _nextDeco.Execute(go);
    }

    private void Move(Transform go)
    {
        go.Rotate(0, 0, _speed, Space.Self);
    }
}
