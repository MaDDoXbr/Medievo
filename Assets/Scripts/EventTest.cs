using System;
using UnityEngine.Events;
using UnityEditor.Events;
using UnityEngine;

public class EventTest : MonoBehaviour {
    public UnityEvent BigExplosionEvent;

    public delegate void voidDelegate();
    public event voidDelegate _GameOver;
    
    public event Action GameOver;

    private void Awake()
    {
        GameOver += GameOverMessage;
        _GameOver += GameOverMessage;
    }

    void Start()
    {
        if (BigExplosionEvent == null)
            BigExplosionEvent = new UnityEvent();

        var targetInfo = UnityEvent.GetValidMethodInfo(this, nameof(ExplodeMe), new Type[0]);
        UnityAction methodDelegate = Delegate.CreateDelegate(typeof(UnityAction), this, targetInfo) as UnityAction;
        UnityEventTools.AddPersistentListener(BigExplosionEvent, methodDelegate);
    }

    public void ExplodeMe()
    {
        Debug.Log("I just blew up!");
    }

    public void GameOverMessage()
    {
        Debug.Log("The game is over");
    }
}
