using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class UIManager : SingletonManager<UIManager>
{
    List<GameUI> uiList = new List<GameUI>();

    public T LoadUI<T>(string resName, params object[] args) where T : GameUI, new()
    {
        var res = ResourceManager.Instance.LoadPrefabAsync(resName);
        var ui = new T
        {
            state = UIState.Loading,
            res = res
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

    public void UnloadUI(GameUI ui)
    {

    }
}
