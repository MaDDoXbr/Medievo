using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRandomIdle : StateMachineBehaviour
{
    public int ClipCount = 4;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("idlerandom", Random.Range(0, ClipCount));    // Ex.: 0..3
    }
}
