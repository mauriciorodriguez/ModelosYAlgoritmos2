﻿using UnityEngine;
using System.Collections;

public class SightScript : MonoBehaviour {

    void LateUpdate()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }
}
