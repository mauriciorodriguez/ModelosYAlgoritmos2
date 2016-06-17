using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour, IScreen
{
    public GameObject prefabPause;
	void Start ()
    {
	
	}
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) ScreenManager.instance.PushPrefab(prefabPause, false);

    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
