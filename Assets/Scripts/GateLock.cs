using System.Collections;
using Syrinj;
using UnityEngine;

public class GateLock:MonoBehaviour, ILock
{
    private const string OpenAnimName = "Open";    //TODO: Pode ser recuperado do GameData, como ScriptableAsset

    public KeyItem ValidKey;
    [GetComponent(typeof(Animation))]
    private Animation _anim;

    public IEnumerator OpenWithKey(KeyItem key)
    {
        if (key == ValidKey)
            OpenGate();
        yield return null;
    }

    private void OpenGate()
    {
        _anim.Play(OpenAnimName);
        this.enabled = false;                     // Só vai abrir uma vez.
    }
}
