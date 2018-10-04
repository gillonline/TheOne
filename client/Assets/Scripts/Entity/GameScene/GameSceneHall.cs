using UnityEngine;
using System.Collections;

class GameSceneHall : GameScene
{
    GameUI mainUI;

    public GameSceneHall() : base()
    {
        name = "Hall";
    }

    public override void OnEnter(params object[] args)
    {
        mainUI = UIManager.Instance.OpenUI<UI_Main>("UI/UI_Main");
    }

    public override void OnLeave()
    {
        mainUI.Close();
        mainUI.Release();
        mainUI = null;
    }
}
