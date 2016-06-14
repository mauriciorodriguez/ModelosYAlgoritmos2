using UnityEngine;
using System.Collections;
using System;

public abstract class Entity : MonoBehaviour, IReusable {

    public virtual void OnAcquire()
    {
        throw new NotImplementedException();
    }

    public void OnCreate()
    {
        throw new NotImplementedException();
    }

    public void OnRelease()
    {
        throw new NotImplementedException();
    }
}
