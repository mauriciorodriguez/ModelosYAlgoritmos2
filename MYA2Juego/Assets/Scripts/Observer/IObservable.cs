using UnityEngine;
using System.Collections;

public interface IObservable
{
    void AddObserver(IObserver obs);
    void RemoveObserver(IObserver obs);
    void Notify(string msg);
}
