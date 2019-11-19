using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IMover : IEventSystemHandler
{
    IEnumerable SetCanMove(bool Value);
    IEnumerable SetDestination(Vector3 Position);
    IEnumerable SetVelocity(Vector3 Velocity);
    Vector3? GetDesiredVelocity();
}
