using UnityEngine;
using UnityEngine.UI;

class UI_Start : GameUI
{
    public override void OnLoaded()
    {
        Find<Button>("bg/start").onClick.AddListener(() => UIManager.Instance.LoadUI<UI_MessageBox>("UI/UI_MessageBox"));
    }
}