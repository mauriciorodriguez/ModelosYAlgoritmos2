using UnityEngine;
using System.Collections;

public class DecoratorAsteroidScale : DecoratorAsteroid
{
    private float amount = 3;

    public DecoratorAsteroidScale(DecoratorAsteroid nxt = null)
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
        var thisClone = new DecoratorAsteroidScale(nextClone);
        return thisClone;
    }

    public override void Execute(Transform go)
    {
        Move(go);
        if (_nextDeco != null) _nextDeco.Execute(go);
    }

    private void Move(Transform go)
    {
        var xyScale = new Vector3(Mathf.PingPong(Time.time, 1) * amount, Mathf.PingPong(Time.time, 1) * amount, 0);
        go.localScale = xyScale;
    }
}
