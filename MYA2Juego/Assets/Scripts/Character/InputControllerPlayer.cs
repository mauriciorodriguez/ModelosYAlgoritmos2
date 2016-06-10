using UnityEngine;
using System.Collections;

public class InputControllerPlayer : MonoBehaviour
{
    public float speed;
    private Vector3 rotationVector;
    public float rotationSpeed;
    private SpriteRenderer _model;

    void Awake()
    {
        _model = transform.GetComponent<SpriteRenderer>();
        //Luego tienen que instanciarse en un pool
    }
	void Start ()
    {
	
	}
	
	void Update ()
    {
        //Movements     
        transform.position += Input.GetAxis(K.INPUT_VERTICAL) * speed * transform.up * Time.deltaTime;
        rotationVector.z = rotationSpeed * -Input.GetAxis(K.INPUT_HORIZONTAL);
        transform.Rotate(rotationVector * Time.deltaTime);


        //Screen Limits
        float cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;

        if (transform.position.y - _model.bounds.size.y / 2 > Camera.main.orthographicSize)
        transform.position = new Vector2(transform.position.x, -Camera.main.orthographicSize - _model.bounds.size.y / 2);

        else if (transform.position.y + _model.bounds.size.y / 2 < -Camera.main.orthographicSize)
        transform.position = new Vector2(transform.position.x, Camera.main.orthographicSize + _model.bounds.size.y / 2);

        if (transform.position.x - _model.bounds.size.x / 2 > cameraWidth)
        transform.position = new Vector2(-cameraWidth - _model.bounds.size.x / 2, transform.position.y);

        else if (transform.position.x + _model.bounds.size.x / 2 < -cameraWidth)
        transform.position = new Vector2(cameraWidth + _model.bounds.size.x / 2, transform.position.y);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
     
	}

    void Fire()
    {
        //Por ahora solo dispara Simple Bullets
        GameObject newBullet;
        newBullet=Instantiate<GameObject>(Factory.BulletFactory("Bullet"));
        newBullet.transform.position = transform.position;
    }
}
