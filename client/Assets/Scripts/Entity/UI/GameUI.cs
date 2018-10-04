using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

abstract class GameUI
{
    public ResourceInstance res;
    public UIState state;
    public string name;
    protected GameObject instance;
    public Transform root;
    public Canvas canvas;

    public void SetGameObject(GameObject instance)
    {
        this.instance = instance;
        root = instance.transform;
        canvas = instance.GetComponent<Canvas>();
    }

    public Transform Find(string path)
    {
        return root.Find(path);
    }

    public T Find<T>(string path) where T : Component
    {
        var tra = root.Find(path);
        if (tra != null)
            return tra.GetComponent<T>();
        else
        {
            Debug.LogWarningFormat("{0} not found {1}", res.path, path);
            return null;
        }
    }

    public void AddImageClickListener(Image img, Action act)
    {
        img.gameObject.AddComponent<EventTrigger>().triggers.Add(new EventTrigger.Entry());
    }

    public void Load()
    {
        SetGameObject(res.CreateInstance<GameObject>());
        state = UIState.Loaded;
        OnLoaded();
    }

    public GameUI Open(params object[] args)
    {
        state = UIState.Open;
        canvas.enabled = true;
        OnOpen(args);

        return this;
    }
    
    public void Close()
    {
        state = UIState.Close;
        canvas.enabled = false;
        OnClose();
    }

    public void SetVisible(bool enable)
    {
        canvas.enabled = enable;
    }

    public void Release()
    {
        state = UIState.Unloaded;
        OnUnloaded();
    }

    public virtual void OnLoaded()
    {

    }

    public virtual void OnOpen(params object[] args)
    {

    }

    public virtual void OnClose()
    {

    }

    public virtual void OnUnloaded()
    {

    }
}