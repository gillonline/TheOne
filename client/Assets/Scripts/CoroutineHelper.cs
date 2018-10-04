using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CoroutineHelper : MonoBehaviour
{
    static CoroutineHelper instance;
    public static CoroutineHelper Instance
    {
        get
        {
            if (instance == null)
            {
                var gameobj = new GameObject("CoroutineHelper");
                instance = gameobj.AddComponent<CoroutineHelper>();
            }
            return instance;
        }
    }

    class CorInstance
    {
        public int id;
        public Coroutine corIns;

        public CorInstance(int id, Coroutine corIns)
        {
            this.id = id;
            this.corIns = corIns;
        }
    }

    List<CorInstance> currentInstanceList = new List<CorInstance>();

    int FindUseableID()
    {
        var id = 1;
        while (true)
        {
            foreach (var item in currentInstanceList)
            {
                if (item.id == id)
                {
                    id++;
                    continue;
                }
            }
            return id;
        }
    }


    public int Begin(Action act)
    {
        var id = FindUseableID();
        var cor = StartCoroutine(CoroutineFunc(act, id));
        currentInstanceList.Add(new CorInstance(id, cor));
        return id;
    }

    public int Begin(Func<IEnumerator> act)
    {
        var id = FindUseableID();
        var cor = StartCoroutine(CoroutineFunc(act.Invoke(), id));
        currentInstanceList.Add(new CorInstance(id, cor));
        return id;
    }

    public void End(int id)
    {
        var ins = currentInstanceList.Find(item => item.id == id);
        if (ins != null)
        {
            StopCoroutine(ins.corIns);
            currentInstanceList.Remove(ins);
        }
    }

    IEnumerator CoroutineFunc(Action act, int id)
    {
        yield return null;
        act.Invoke();
        yield return null;
        var ins = currentInstanceList.Find(item => item.id == id);
        if (ins != null)
        {
            currentInstanceList.Remove(ins);
        }
    }

    IEnumerator CoroutineFunc(IEnumerator itor, int id)
    {
        yield return itor;
        var ins = currentInstanceList.Find(item => item.id == id);
        if (ins != null)
            currentInstanceList.Remove(ins);
    }
}
