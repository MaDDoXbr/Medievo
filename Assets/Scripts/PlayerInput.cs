using System;
using System.Collections;
using System.Net.Security;
using UnityEngine;
using UnityEngine.WSA;
public enum MouseButton { Left = 0, Right = 1, Middle = 2 }    //TODO: Mover todos os enums para uma única classe

public class PlayerInput: MonoBehaviour, ICommands
{
    private bool _blockInput;
    
    public IEnumerable BlockInput(bool Value)
    {
        _blockInput = true;
        yield break;
    }

    private void Update()
    {
        if (_blockInput)
            return;
        if (Input.GetMouseButtonDown((int) MouseButton.Left))
        {
            gameObject.Send<ICmdReceiver>(_ => _.MousePressed(MouseButton.Left));
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // "out var hit" é uma declaração *inline* inferida (var) da variável hit, que é apenas de saída (out)
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity))   //, ~(1 << LayerMask.NameToLayer("Enemy"))))
                gameObject.Send<IMover>(_=>_.SetDestination(hit.point));
        }
        // Pode ser utilizado por um script CmdReceiver para disparar ações especiais, por exemplo
        if (Input.GetMouseButtonDown((int) MouseButton.Right))
            gameObject.Send<ICmdReceiver>(_ => _.MousePressed(MouseButton.Right));
        if (Input.GetMouseButtonDown((int) MouseButton.Middle))
            gameObject.Send<ICmdReceiver>(_ => _.MousePressed(MouseButton.Middle));
        // Releases
        if (Input.GetMouseButtonUp((int) MouseButton.Left))
            gameObject.Send<ICmdReceiver>(_ => _.MouseReleased(MouseButton.Left));
        if (Input.GetMouseButtonUp((int) MouseButton.Right))
            gameObject.Send<ICmdReceiver>(_ => _.MouseReleased(MouseButton.Right));
        if (Input.GetMouseButtonUp((int) MouseButton.Middle))
            gameObject.Send<ICmdReceiver>(_ => _.MouseReleased(MouseButton.Middle));        
    }
}
