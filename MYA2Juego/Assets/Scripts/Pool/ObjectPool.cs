using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool<T> where T : IReusable
{
    public delegate GameObject FactoryDelegate();

    private Stack<GameObject> _objects;
    private FactoryDelegate _factory;
    private GameObject _containerGameObject;

    public ObjectPool(FactoryDelegate factory, string containerN, int quantity = 5)
    {
        _objects = new Stack<GameObject>();
        _factory = factory;
        _containerGameObject = GameObject.FindGameObjectWithTag(containerN);
        if (quantity >= 0)
        {
            for (int i = 0; i < quantity; i++)
            {
                _objects.Push(Create());
            }
        }

    }

    public GameObject GetObject()
    {
        GameObject elem;
        if (_objects.Count > 0)
        {
            elem = _objects.Pop();
        }
        else
        {
            elem = Create();
        }
        elem.GetComponent<T>().OnAcquire();
        return elem;
    }

    public void PutBackObject(GameObject obj)
    {
        obj.GetComponent<T>().OnRelease();
        _objects.Push(obj);
    }

    private GameObject Create()
    {
        var elem = _factory();
        elem.GetComponent<T>().OnCreate();
        return elem;
    }
}
