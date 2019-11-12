using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ICmdReceiver : IEventSystemHandler
{
    IEnumerable MousePressed(MouseButton ButtonClicked);
    IEnumerable MouseReleased(MouseButton ButtonReleased);
}
