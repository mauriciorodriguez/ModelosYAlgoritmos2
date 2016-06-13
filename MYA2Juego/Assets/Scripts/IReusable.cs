using UnityEngine;
using System.Collections;

public interface IReusable
{
    void OnAcquire();
    void OnRelease();
    void OnCreate();
}
