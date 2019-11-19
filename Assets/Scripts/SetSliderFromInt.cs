using System.Collections;
using System.Collections.Generic;
using Syrinj;
using UnityEngine;
using UnityEngine.UI;

public class SetSliderFromInt : MonoBehaviour {
    public IntReference SourceInt;

    [GetComponent]
    private Slider _slider;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        var sourceVar = SourceInt.Variable;
        _slider.value = sourceVar.Value / sourceVar.DefaultValue;
    }
}
