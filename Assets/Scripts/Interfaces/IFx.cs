using System.Collections;
using UnityEngine.EventSystems;

public interface IFx : IEventSystemHandler
{
    IEnumerable SetAnimBool(string paramName, bool Value);
    IEnumerable SetAnimTrigger(string paramName);
    IEnumerable SetAnimInteger(string paramName, int Value);
    IEnumerable SetAnimFloat(string paramName, float Value);
}
