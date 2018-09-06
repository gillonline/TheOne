using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

class UI_MessageBox : GameUI
{
    public override void OnLoaded()
    {
        Find<Button>("bg/ok").onClick.AddListener(() => Application.Quit());
        Find<Button>("bg/cancel").onClick.AddListener(() => Close());
        //Find<EventTrigger>("mask").OnPointerClick
    }

    public override void OnOpen(params object[] args)
    {
        Find<Text>("bg/txt").text = "Are you sure to quit game?";
        
    }
}