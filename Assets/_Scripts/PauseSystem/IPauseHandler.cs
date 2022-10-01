using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPauseHandler
{
    void Register(IPauseHandler handler);
    void UnRegister(IPauseHandler handler);
    void Pause(bool isPaused);
}
