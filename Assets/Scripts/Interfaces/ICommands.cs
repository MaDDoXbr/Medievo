using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ICommands : IEventSystemHandler
{
    IEnumerable BlockInput(bool Value);
}
