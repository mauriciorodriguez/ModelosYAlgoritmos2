using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed;


    void OnEnable()
    {

        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        transform.LookAt(Vector3.forward, Vector3.Cross(Vector3.forward, mousePosition));


    }


    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

}
