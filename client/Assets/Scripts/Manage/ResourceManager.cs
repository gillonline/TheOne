using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ResourceManager : MonoBehaviour
{
    static ResourceManager _instance;
    public static ResourceManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject("ResourceManager");
                _instance = go.AddComponent<ResourceManager>();
            }
            return _instance;
        }
    }

    public List<ResourceInstance> prefabList = new List<ResourceInstance>();

    public ResourceInstance LoadPrefabAsync(string path, Action<ResourceInstance> loaded = null)
    {
        var resIns = prefabList.Find(item => item.path == path);
        if (resIns == null)
        {
            resIns = new ResourceInstance(path);
            if (loaded != null)
                resIns.OnLoaded += loaded;
            prefabList.Add(resIns);
            StartCoroutine(resIns.StartLoad());
            return resIns;
        }
        else
        {
            return resIns;
        }
    }

    public void UnloadPrefab(string path, bool destroyClone)
    {
        var res = prefabList.Find(item => item.path == path);
        if (res != null)
        {
            res.Release(destroyClone);

        }
    }
    
    private void Update()
    {
        foreach (var res in prefabList)
        {
            
        }
    }
}
