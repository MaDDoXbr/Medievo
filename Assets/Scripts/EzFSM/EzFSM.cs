using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Ez.FSM
{
    public class EzFSM : MonoBehaviour, IFSM
    {
        public FSMStateID CurrentState;
        [SerializeField]
        public FSMstateIDActionDictionary ActionMap;
        
        public void Update()
        {
            if (CurrentState == null)
                return;
            var CurrentAction = ActionMap[CurrentState];
            if (CurrentAction == null)
                return;
            var CurrentUpdateAction = CurrentAction.Update;
            CurrentUpdateAction?.Invoke();
        }
        
        public IEnumerable StateEnter(FSMStateID ID)
        {
            CurrentState = ID;
            if (ActionMap[ID] == null || ActionMap[ID].Enter == null)
                yield break;
            ActionMap[ID].Enter.Invoke();
        }

        public IEnumerable StateExit(FSMStateID ID)
        {
            if (ActionMap[ID] == null || ActionMap[ID].Exit == null)
                yield break;
            ActionMap[ID].Exit.Invoke();
        }

        public IEnumerable StateUpdate(FSMStateID ID)
        {
            if (ActionMap[ID] == null || ActionMap[ID].Update == null)
                yield break;
            ActionMap[ID].Update.Invoke();
        }

        public FSMStateID GetState()
        {
            return CurrentState;
        }

    }

    [System.Serializable]
    public class FSMStateActions
    {
        public UnityEvent Enter;
        public UnityEvent Exit;
        public UnityEvent Update;
    }

    [System.Serializable]
    public class FSMstateIDActionDictionary : SerializableDictionary<FSMStateID, FSMStateActions> {}
}