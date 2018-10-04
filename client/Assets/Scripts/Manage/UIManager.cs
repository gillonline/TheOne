using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class UIManager : SingletonManager<UIManager>
{
    List<GameUI> uiList = new List<GameUI>();

    public T OpenUI<T>(string resName, params object[] args) where T : GameUI, new()
    {
        var ui = uiList.Find(item => item.name.Equals(resName));
        if (ui != null)
            return ui.Open(args) as T;
        else
            return LoadUI<T>(resName, args);
    }

    public T LoadUI<T>(string resName, params object[] args) where T : GameUI, new()
    {
        var res = ResourceManager.Instance.LoadPrefabAsync(resName);
        var ui = new T
        {
            state = UIState.Loading,
            res = res,
            name = resName 
        };
        if (res.loadCompleted)
        {
            LoadedUI(ui, res, args);
        }
        else
        {
            res.OnLoaded += (r) => LoadedUI(ui, r, args);
        }

        uiList.Add(ui);
        return ui;
    }

    void LoadedUI(GameUI ui, ResourceInstance res, params object[] args)
    {
        if (ui.state == UIState.Loading)
        {
            ui.Load();
            ui.Open(args);
        }
        else
        {
            if (ui.state == UIState.Unloaded)
            {

            }
            else if (ui.state == UIState.Close)
            {
                ui.Load();
            }
        }
    }

    public T GetUI<T>(string resName) where T : GameUI, new()
    {
        var ui = uiList.Find(item => item.name.Equals(resName));
        return ui as T;
    }

    public void CloseAll()
    {
        uiList.ForEach(ui => ui.Close());
    }
}
