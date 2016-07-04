using UnityEngine;
using System.Collections;
using System;

public class Bullet : Ammo, IReusable
{
    public override void OnAcquire()
    {
        base.OnAcquire();
        _currentLifetime = lifeTime;
    }

    /*void OnEnable()
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        transform.LookAt(Vector3.forward, Vector3.Cross(Vector3.forward, mousePosition));
    }*/

    protected override void Update()
    {
        //transform.Translate(transform.up * speed * Time.deltaTime);
        transform.position += transform.up * speed * Time.deltaTime;
        base.Update();
        if (_currentLifetime <= 0)
        {
            PoolManager.instance.poolBullets.PutBackObject(gameObject);
        }
    }
}
