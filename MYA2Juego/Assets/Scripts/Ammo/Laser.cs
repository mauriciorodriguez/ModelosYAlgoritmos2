using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    public float laserDistance, lasertWidth, damage;

    private LineRenderer _line;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _line.SetPosition(0, new Vector2(0, laserDistance));
        _line.SetWidth(lasertWidth, lasertWidth);
    }
}
