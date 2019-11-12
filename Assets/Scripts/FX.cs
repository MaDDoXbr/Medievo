using System.Collections;
using System.Collections.Generic;
using Syrinj;
using UnityEngine;

public class FX : MonoBehaviour, IFx
{
    public Animator FxAnimator;
    public AudioSource FxAudioSource;

    public IEnumerable SetAnimBool(string paramName, bool Value)
    { 
        FxAnimator.SetBool(paramName, Value);
        yield break;
    }

    public IEnumerable SetAnimTrigger(string paramName)
    {
        FxAnimator.SetTrigger(paramName);
        yield break;
    }

    public IEnumerable SetAnimInteger(string paramName, int Value)
    {
        FxAnimator.SetInteger(paramName, Value);
        yield break;
    }

    public IEnumerable SetAnimFloat(string paramName, float Value)
    {
        Debug.Log("Value: "+Value);
        FxAnimator.SetFloat(paramName, Value);
        yield break;
    }
}
