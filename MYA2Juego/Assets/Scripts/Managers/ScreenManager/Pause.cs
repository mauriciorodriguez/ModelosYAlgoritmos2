using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour, IScreen
{
  
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ScreenManager.instance.PopScreen();
    }

    public void Resume()
    {
        ScreenManager.instance.PopScreen();
    }

    public void Exit()
    {
        ScreenManager.instance.PopScreen();
        ScreenManager.instance.PopScreen();
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    } 
}
