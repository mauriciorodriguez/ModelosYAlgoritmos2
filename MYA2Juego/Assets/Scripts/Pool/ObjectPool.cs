using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool<T>
{
    public delegate T FactoryDelegate();

    private Stack<T> _objects;
    private FactoryDelegate _factory;

    public ObjectPool(FactoryDelegate factory, int quantity = 10)
    {
        _objects = new Stack<T>();
        _factory = factory;
        if (quantity >= 0)
        {
            for (int i = 0; i < quantity; i++)
            {
                _objects.Push(Create());
            }
        }

    }

    public T GetObject()
    {
        if (_objects.Count > 0)
        {
            return _objects.Pop();
        }
        else
        {
            return Create();
        }
    }

    public void PutBackObject(T obj)
    {
        _objects.Push(obj);
    }

    private T Create()
    {
        return _factory();
    }
}
