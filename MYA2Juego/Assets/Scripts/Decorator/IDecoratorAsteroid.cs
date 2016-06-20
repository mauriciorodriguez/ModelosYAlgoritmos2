using UnityEngine;
using System.Collections;

public interface IDecoratorAsteroid
{
    void SetDecorator(IDecoratorAsteroid decorator);
    void Execute(GameObject go);
}
