namespace Ez.FSM
{
    using System.Collections;
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using UnityEngine;
    using UnityEngine.EventSystems;
    public interface IFSM : IEventSystemHandler
    {
        IEnumerable StateEnter(FSMStateID ID);
        IEnumerable StateExit(FSMStateID ID);
        IEnumerable StateUpdate(FSMStateID ID);
        FSMStateID GetState();
    }
}