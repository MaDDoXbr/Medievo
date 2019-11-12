using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILock
{
    IEnumerator OpenWithKey(KeyItem key);
}
