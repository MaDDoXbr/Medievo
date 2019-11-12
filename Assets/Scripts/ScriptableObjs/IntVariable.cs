using NaughtyAttributes;
using UniRx;
using UnityEngine;

public class IntVariable: ScriptableObject
{
    public bool ResetOnPlay;
    public int DefaultValue;
    //private int _value;
    [SerializeField] //, PropertyBackingField(nameof(Value))
    private int _value;

    [ShowNativeProperty]
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }

    private void OnEnable()
    {
        if (ResetOnPlay)
            _value = DefaultValue;
    }
}