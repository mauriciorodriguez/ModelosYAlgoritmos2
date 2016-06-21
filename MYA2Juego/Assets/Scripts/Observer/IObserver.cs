using UnityEngine;
using System.Collections;

public interface IObserver
{
    void Notify(GameObject caller, string msg);
}
