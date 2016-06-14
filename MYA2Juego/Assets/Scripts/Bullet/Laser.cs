﻿using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    private LineRenderer line;
    public float laserDistance;
    private Vector3 _dir;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    private void Start()
    {
    }

    private void Update()
    {
        line.SetPosition(0, new Vector2(0, laserDistance));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.parent.up * laserDistance, 1 << K.LAYER_ASTEROID);
        Debug.DrawRay(transform.position, transform.parent.up * laserDistance);

        if (hit.collider != null) print(hit.collider.gameObject.name);

    }
}