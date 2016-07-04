using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ViewLives : MonoBehaviour, IObserver
{
    public GameObject LifePrefab;
    private List<GameObject> _lifesPrefabs;

    private void Start()
    {
        _lifesPrefabs = new List<GameObject>();
        GameObject.FindGameObjectWithTag(K.TAG_MODEL).GetComponent<Model>().AddObserver(this);
    }

    public void Notify(GameObject caller, string msg)
    {
        switch (msg)
        {
            case K.OBSERVER_PLAYER_ADD_LIVES:
                UpdateLifes(caller.GetComponent<Model>().currentLives);
                break;
            case K.OBSERVER_PLAYER_LIVES:
                UpdateLifes(caller.GetComponent<Model>().currentLives);
                break;
            default:
                break;
        }
    }

    private void UpdateLifes(int playerLifes)
    {
        foreach (var life in _lifesPrefabs)
        {
            Destroy(life);
        }
        for (int i = 0; i < playerLifes; i++)
        {
            var go = Instantiate(LifePrefab);
            go.transform.SetParent(GameObject.FindGameObjectWithTag(K.TAG_LIFES).transform);
            Vector3 aux = new Vector3(-860 + i * 100, 420, 0);
            go.transform.localScale = Vector3.one;
            go.GetComponent<RectTransform>().localPosition = aux;
            _lifesPrefabs.Add(go);
        }
    }
}
