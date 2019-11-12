using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenTestMover : MonoBehaviour {
    public float duration = 2f;

    public Ease EaseMode;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveX(-1f, duration)
            .SetRelative(true)
            .SetEase(EaseMode);
    }
}
