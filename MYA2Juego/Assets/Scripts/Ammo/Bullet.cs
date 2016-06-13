using UnityEngine;
using System.Collections;
using System;

public class Bullet : MonoBehaviour, IReusable
{
    public float speed;
    public float lifeTime;

    private float _currentLifetime;

    public void OnAcquire()
    {
        gameObject.SetActive(true);
        _currentLifetime = lifeTime;
    }

    public void OnCreate()
    {
        transform.parent = GameObject.FindGameObjectWithTag(K.TAG_BULLETS).transform;
        gameObject.SetActive(false);
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
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

    void Update()
    {
        //transform.Translate(transform.up * speed * Time.deltaTime);
        transform.position += transform.up * speed * Time.deltaTime;
        _currentLifetime -= Time.deltaTime;
        if (_currentLifetime <= 0)
        {
            GameObject.FindGameObjectWithTag(K.TAG_MANAGERS).GetComponent<PoolManager>().poolBullets.PutBackObject(gameObject);
        }
    }
}
