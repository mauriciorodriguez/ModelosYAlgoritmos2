using UnityEngine;
using System.Collections;

public class MenuScreen : MonoBehaviour, IScreen
{
    public GameObject prefabGame;
	void Start ()
    {
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) StartGame();
    }
    public void StartGame()
    {
        Debug.Log("Start game");
        ScreenManager.instance.PushPrefab(prefabGame, true);
    }
    public GameObject GetGameObject()
    {
        return gameObject;
    } 
}
