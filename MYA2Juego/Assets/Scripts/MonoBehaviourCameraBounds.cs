using UnityEngine;
using System.Collections;

public abstract class MonoBehaviourCameraBounds : MonoBehaviour
{
    protected SpriteRenderer _spriteModel;
    protected Camera _mainCamera;

    protected virtual void Start()
    {
        _spriteModel = GetComponent<SpriteRenderer>();
        if (!_spriteModel) _spriteModel = GetComponentInChildren<SpriteRenderer>();
        _mainCamera = Camera.main;
    }

    protected virtual void Update()
    {
        CheckScreenBorder();
    }

    protected void CheckScreenBorder()
    {
        //Screen Limits
        float cameraWidth = _mainCamera.orthographicSize * _mainCamera.aspect;

        if (transform.position.y - _spriteModel.bounds.size.y / 2 > _mainCamera.orthographicSize)
            transform.position = new Vector2(transform.position.x, -_mainCamera.orthographicSize - _spriteModel.bounds.size.y / 2);

        else if (transform.position.y + _spriteModel.bounds.size.y / 2 < -_mainCamera.orthographicSize)
            transform.position = new Vector2(transform.position.x, _mainCamera.orthographicSize + _spriteModel.bounds.size.y / 2);

        if (transform.position.x - _spriteModel.bounds.size.x / 2 > cameraWidth)
            transform.position = new Vector2(-cameraWidth - _spriteModel.bounds.size.x / 2, transform.position.y);

        else if (transform.position.x + _spriteModel.bounds.size.x / 2 < -cameraWidth)
            transform.position = new Vector2(cameraWidth + _spriteModel.bounds.size.x / 2, transform.position.y);
    }
}
