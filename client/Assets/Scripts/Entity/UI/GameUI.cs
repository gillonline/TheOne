using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

abstract class GameUI
{
    public ResourceInstance res;
    public UIState state;
    protected GameObject instance;
    public Transform root;

    public void SetGameObject(GameObject instance)
    {
        this.instance = instance;
        root = instance.transform;
    }

    public T Find<T>(string path) where T : Component
    {
        return root.Find(path).GetComponent<T>();
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

    public void Open(params object[] args)
    {
        state = UIState.Open;
        instance.SetActive(true);
        OnOpen(args);
    }
    
    public void Close()
    {
        state = UIState.Close;
        instance.SetActive(false);
        OnClose();
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