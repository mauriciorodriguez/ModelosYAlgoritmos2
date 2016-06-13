using UnityEngine;
using System.Collections;
using System;

public class Asteroid : MonoBehaviour, IReusable
{
    public static int _count = 0;
    public int hp;
    public bool isOutOfScreen { private set; get; }

    private Vector3 _position, _rotation;

    public void OnAcquire()
    {
    }

    public void OnRelease()
    {
    }

    public void OnCreate()
    {
        gameObject.transform.parent = GameObject.FindGameObjectWithTag(K.TAG_ENEMIES).transform;
        gameObject.SetActive(false);
        gameObject.name += " : " + (_count++);
    }
}
