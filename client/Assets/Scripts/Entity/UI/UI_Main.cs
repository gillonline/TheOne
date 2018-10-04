using UnityEngine;
using UnityEngine.UI;

class UI_Main : GameUI
{
    public override void OnLoaded()
    {
        Find<Button>("bg/start").onClick.AddListener(OnClickStart);
        Find<Button>("bg/load").onClick.AddListener(OnClickLoad);
    }

    public override void OnUnloaded()
    {
        Find<Button>("bg/start").onClick.RemoveListener(OnClickStart);
    }

    public override void OnOpen(params object[] args)
    {
        UICommonEvent.Add("resume_main_ui", Resume);
    }

    public override void OnClose()
    {
        UICommonEvent.Remove("resume_main_ui", Resume);
    }

    void OnClickStart()
    {
        //UIManager.Instance.LoadUI<UI_MessageBox>("UI/UI_MessageBox");

    }

    void OnClickLoad()
    {
        UIManager.Instance.OpenUI<UI_StageList>("UI/UI_StageList");
        SetVisible(false);
    }

    void Resume()
    {
        SetVisible(true);
    }
}