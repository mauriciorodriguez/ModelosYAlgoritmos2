using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
    public static int _count = 0;
    public int hp;
    public bool isOutOfScreen { private set; get; }

    private Vector3 _position, _rotation;

    public Asteroid()
    {
        gameObject.name = this.GetType().ToString() + ":" + (_count++);
    }
}
