using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ScreenManager : MonoBehaviour
{
    public GameObject prefabMenuPpal;
    Stack<StackPart> _screenStack;
    public static ScreenManager instance { get; private set; }

    class StackPart
    {
        public IScreen screen;
        public bool deactivated;
    }

    void Awake()
    {
        Debug.Assert(instance == null);
        instance = this;
        _screenStack = new Stack<StackPart>();
    }
    void Start()
    {
        ScreenManager.instance.PushPrefab(prefabMenuPpal, true);
    }
    public void PushPrefab(GameObject prefab, bool deactivateLower)
    {
        var menu = GameObject.Instantiate(prefab);
        IScreen scr = menu.GetComponent<IScreen>();
        Debug.Assert(scr != null);
        PushScreen(scr, deactivateLower);
    }

    public void PushScreen(IScreen screen, bool deactivateLower)
    {
        if (_screenStack.Count > 0)
        {
            if (deactivateLower) _screenStack.Peek().screen.GetGameObject().SetActive(false);
            else SetUpdate(_screenStack.Peek().screen.GetGameObject(), false);
        }

        var part = new StackPart();
        part.screen = screen;
        part.deactivated = deactivateLower;
        _screenStack.Push(part);
    }
    void SetUpdate(GameObject go, bool value)
    {
        foreach (var c in go.GetComponentsInChildren<MonoBehaviour>()) c.enabled = value;
    }

    public void PopScreen()
    {
        //Debug.Log(String.Format("Pop con {0} elementos", _screenStack.Count));

        if (_screenStack.Count > 1)
        {
            var part = _screenStack.Peek();
            //Debug.Log("Destroy");
            _screenStack.Pop();
            if (part.deactivated) _screenStack.Peek().screen.GetGameObject().SetActive(true);
            else SetUpdate(_screenStack.Peek().screen.GetGameObject(), true);
            GameObject.DestroyObject(part.screen.GetGameObject());
        }
    }
}
