using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CoroutineObject : IEnumerator
{
    public object Current
    {
        get
        {
            throw new System.NotImplementedException();
        }
    }

    public virtual bool MoveNext()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Reset()
    {
        throw new System.NotImplementedException();
    }
}
