using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

class UI_CreateStage : GameUI
{
    public override void OnLoaded()
    {
        Find<Button>("board/ok").onClick.AddListener(OnClickOK);
        Find<Button>("board/cancel").onClick.AddListener(OnClickCancel);

    }

    void OnClickOK()
    {
        var name = Find<InputField>("board/name/InputField").text;
        var width = Find<InputField>("board/size/x/InputField").text;
        var height = Find<InputField>("board/size/y/InputField").text;
        var desc = Find<InputField>("board/desc/InputField").text;
        var stageConfig = new StageConfig(name, int.Parse(width), int.Parse(height))
        {
            desc = desc
        };

        GameSceneManager.Instance.SwitchScene("CreateStage", stageConfig);

        Close();
    }

    void OnClickCancel()
    {
        Close();
    }
}
