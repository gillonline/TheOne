using UnityEngine;
using System.Collections;

class GameSceneStart : GameScene
{
    GameUI StartUI;

    public GameSceneStart() : base()
    {
        name = "Start";
    }

    public override void OnEnter()
    {
        StartUI = UIManager.Instance.LoadUI<UI_Start>("UI/UI_Start");
    }

    public override void OnLeave()
    {
        StartUI.Release();
    }
}
