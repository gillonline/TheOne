using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CoroutineObject : IEnumerator
{
    public object Current
    {
        get
        {
            return null;
        }
    }

    public virtual bool MoveNext()
    {
        return false;
    }

    public virtual void Reset()
    {

    }
}
