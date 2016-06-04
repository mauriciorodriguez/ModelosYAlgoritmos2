using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    private Vector3 _mousePositionInWorld;
    private Vector3 _desiredViewPoint;

    private void Update()
    {
        _mousePositionInWorld = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                Input.mousePosition.z - Camera.main.transform.position.z)
            );
        _desiredViewPoint.x = _mousePositionInWorld.x - transform.up.x;
        _desiredViewPoint.y = _mousePositionInWorld.y - transform.up.y;
        transform.up = _desiredViewPoint;
    }
}
