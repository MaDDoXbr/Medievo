using System.Collections;
using UnityEngine.EventSystems;

public interface IMover : IEventSystemHandler
{
    IEnumerable SetCanMove(bool Value);
}
