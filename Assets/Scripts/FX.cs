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
        //Debug.Log("Value: "+Value);
        FxAnimator.SetFloat(paramName, Value);
        yield break;
    }

    void OnAnimatorMove()
    {
        //navAgent.velocity = FxAnimator.deltaPosition / Time.deltaTime;
        gameObject.Send<IMover>(_ => _.SetVelocity(FxAnimator.deltaPosition / Time.deltaTime));
 
        //Jeito "acoplado":
        //transform.rotation = Quaternion.LookRotation(navAgent.desiredVelocity);
        
        // O "?? Vector3.zero" é uma checagem de segurança. Caso o Request falhe (ex.: IMover não encontrado), retorna um (0,0,0)
        var desiredVelocity = gameObject.Request<IMover, Vector3?>(_ => _.GetDesiredVelocity()) ?? Vector3.zero;
        transform.rotation = Quaternion.LookRotation(desiredVelocity);
    }
}
