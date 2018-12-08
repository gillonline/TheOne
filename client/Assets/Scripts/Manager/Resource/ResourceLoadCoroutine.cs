using UnityEngine;
using System.Collections;

class ResourceLoadCoroutine : CoroutineObject
{
    ResourceInstance res;

    public ResourceLoadCoroutine(ResourceInstance res)
    {
        this.res = res;
    }

    public override bool MoveNext()
    {
        return res.loadProgress < 1f;
    }

    public override void Reset()
    {
        base.Reset();
    }
}
