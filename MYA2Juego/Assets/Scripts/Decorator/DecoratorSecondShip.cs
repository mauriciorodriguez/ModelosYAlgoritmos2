using UnityEngine;
using System.Collections;
using UnityEngine.Sprites;

public class DecoratorSecondShip: MonoBehaviour, IDecoratorProxy
{
    public GameObject master;
    public bool flagDestroy;
    //public int life;

    public void Awake()
    {
        transform.gameObject.GetComponent<SpriteRenderer>().sprite = master.GetComponent<SpriteRenderer>().sprite;
    }

    public void LateUpdate()
    {
        if (flagDestroy==true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            transform.position = new Vector3(master.transform.position.x + 2f, master.transform.position.y, master.transform.position.z);
            transform.rotation = new Quaternion(master.transform.rotation.x, master.transform.rotation.y, master.transform.rotation.z, master.transform.rotation.w);
        }

        
        
    }



    public void DestroyShip()
    {
        flagDestroy = true;
    }



}
