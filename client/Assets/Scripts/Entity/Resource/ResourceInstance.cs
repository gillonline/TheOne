using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ResourceInstance
{
    public string path;
    public float loadProgress;
    public ResourceLoadCoroutine loadCoroutine;
    public event Action<ResourceInstance> OnLoaded;
    public bool loadCompleted;
    public UnityEngine.Object asset;
    public ResourceLoopState state;

    public List<UnityEngine.Object> instantiateList = new List<UnityEngine.Object>();

    public ResourceInstance(string path)
    {
        state = ResourceLoopState.Start;
        loadProgress = 0f;
        this.path = path;
        loadCompleted = false;
        loadCoroutine = new ResourceLoadCoroutine(this);
    }

    public IEnumerator StartLoad()
    {
        state = ResourceLoopState.Loading;
#if UNITY_EDITOR
        yield return null;
        asset = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/DevResources/" + path + ".prefab");
#else
        Debug.LogWarningFormat("not define load code");
#endif
        state = ResourceLoopState.Idle;

        if (asset != null)
        {
            loadProgress = 1f;
            loadCompleted = true;
            OnLoaded.Invoke(this);
            OnLoaded = null;
        }
        else
            Debug.LogWarningFormat("prefab load error:{0}", path);

        OnLoaded = null;
    }

    public T CreateInstance<T>() where T : UnityEngine.Object
    {
        if (asset != null)
        {
            var ins = UnityEngine.Object.Instantiate<T>(asset as T);
            instantiateList.Add(ins);
            return ins;
        }
        else
        {
            return null;
        }
    }

    public void Release(bool destroyInstantiate)
    {
        if (destroyInstantiate)
        {
            instantiateList.ForEach(item => UnityEngine.Object.Destroy(item));
            instantiateList.Clear();
        }
        Resources.UnloadAsset(asset);
    }
}