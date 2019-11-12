using System;
using System.Collections;
using System.Collections.Generic;
using Ez.Msg;
using Syrinj;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMover : MonoBehaviour, IMover, ICmdReceiver
{
    private bool _canMove = true;
    private bool _leftClick, _rightClick, _middleClick;
    [GetComponent(typeof(NavMeshAgent))]
    private NavMeshAgent _agent;

    private void Update()
    {
        if (!_canMove) 
            return;
        
        var velocity = _agent.velocity.magnitude;
        Debug.Log("velocity: "+velocity);
        // Manda mensagem pra alterar o parâmetro speed do Animator
        gameObject.Send<IFx>(_ => _.SetAnimFloat("speed", velocity), true);
        
        if (_leftClick)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))   //, ~(1 << LayerMask.NameToLayer("Enemy"))))
            {
                _agent.SetDestination(hit.point);
            }
        }
    }

    public IEnumerable SetCanMove(bool Value)
    {
        _canMove = Value;
        yield break;
    }

    public IEnumerable MousePressed(MouseButton ButtonClicked)
    {
        switch (ButtonClicked) {
            case MouseButton.Left:
                _leftClick = true; break;
            case MouseButton.Right:
                _rightClick = true; break;
            case MouseButton.Middle:
                _middleClick = true; break;               
        }
        yield break;
    }

    public IEnumerable MouseReleased(MouseButton ButtonReleased)
    {
        switch (ButtonReleased) {
            case MouseButton.Left:
                _leftClick = false; break;
            case MouseButton.Right:
                _rightClick = false; break;
            case MouseButton.Middle:
                _middleClick = false; break;               
        }
        yield break;
    }
}
