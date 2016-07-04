using UnityEngine;
using System.Collections;

public interface IObserver
{
    void Notify(Model caller, string msg);
}
