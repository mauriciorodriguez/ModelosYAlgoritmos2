using UnityEngine;
using System.Collections;

public class Laser : Ammo
{
    private LineRenderer _line;
    public float laserDistance;
    public float superWidth;
    public float superHeight;
    private float _defaultDistance;
    public float defaultWidth;
    void Awake()
    {
        _line = GetComponent<LineRenderer>();
        _defaultDistance = laserDistance;
    }

    protected override void Update()
    {
        _line.SetPosition(0, new Vector2(0, laserDistance));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.parent.up * laserDistance, 1 << Config.LAYER_ASTEROID);
        Debug.DrawRay(transform.position, transform.parent.up * laserDistance);
    }

    public void EnablePowerup()
    {
        print("act");
        _line.SetWidth(superWidth, superWidth);
        laserDistance = superHeight;
        GetComponent<BoxCollider2D>().size = new Vector2(superWidth, 9.6f);
        GetComponent<BoxCollider2D>().offset = new Vector2(GetComponent<BoxCollider2D>().offset.x, 5.19f);
    }
    public void DisablePowerup()
    {
        print("disable " + defaultWidth);
        _line.SetWidth(defaultWidth, defaultWidth);
        laserDistance = _defaultDistance;
        GetComponent<BoxCollider2D>().size = new Vector2(defaultWidth, _defaultDistance);
        GetComponent<BoxCollider2D>().offset = new Vector2(GetComponent<BoxCollider2D>().offset.x, 2.5f);
    }
}
