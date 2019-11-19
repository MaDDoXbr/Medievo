using System;
using System.Collections;
using System.Collections.Generic;
using Ez.Msg;
using Syrinj;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharMover : MonoBehaviour, IMover
{
    private bool _canMove = true;
    //private bool _leftClick, _rightClick, _middleClick;
    [GetComponent(typeof(NavMeshAgent))]
    private NavMeshAgent _agent;

    private void Update()
    {
        if (!_canMove) 
            return;
        
        //var velocity = _agent.velocity.magnitude;
        //Debug.Log("velocity: "+velocity);
        var velocity = _agent.hasPath ? _agent.velocity.magnitude : 0f;
        // Manda mensagem pra alterar o parâmetro speed do Animator
        gameObject.Send<IFx>(_ => _.SetAnimFloat("speed", velocity), true);
    }

    public IEnumerable SetDestination(Vector3 Position)
    {
        _agent.SetDestination(Position); yield break;
    }

    public IEnumerable SetVelocity(Vector3 Velocity)
    {
        _agent.velocity = Velocity; yield break;
    }

    public Vector3? GetDesiredVelocity()
    {
        return _agent.desiredVelocity;
    }

    public IEnumerable SetCanMove(bool Value)
    {
        _canMove = Value; yield break;
    }

//    public IEnumerable MousePressed(MouseButton ButtonClicked)
//    {
//        switch (ButtonClicked) {
//            case MouseButton.Left:
//                _leftClick = true; break;
//            case MouseButton.Right:
//                _rightClick = true; break;
//            case MouseButton.Middle:
//                _middleClick = true; break;               
//        }
//        yield break;
//    }

//    public IEnumerable MouseReleased(MouseButton ButtonReleased)
//    {
//        switch (ButtonReleased) {
//            case MouseButton.Left:
//                _leftClick = false; break;
//            case MouseButton.Right:
//                _rightClick = false; break;
//            case MouseButton.Middle:
//                _middleClick = false; break;               
//        }
//        yield break;
//    }
}
