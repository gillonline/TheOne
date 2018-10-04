using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

class UI_StageList : GameUI
{
    class StageItem
    {
        StageConfig config;
        Transform clone;

        public StageItem(Transform clone, StageConfig config)
        {
            this.config = config;
            this.clone = GameObject.Instantiate(clone.gameObject).transform;
            this.clone.transform.SetParent(clone.parent);
            this.clone.transform.localScale = Vector3.one;
        }

        public void Release()
        {
            GameObject.Destroy(clone.gameObject);
        }
    }

    List<StageItem> list = new List<StageItem>();
    Transform tmp;

    public override void OnLoaded()
    {
        tmp = Find("bg/sv/Viewport/Content/Button");
        var back = Find("back");
        ClickMonitor.AddEvent(back, (ev)=>Close());
        var create = Find("create");
        ClickMonitor.AddEvent(create, OnClickCreate);
    }

    public override void OnOpen(params object[] args)
    {
        var stageList = StageManager.Instance.stageList;
        foreach (var stage in stageList)
        {
            var item = new StageItem(tmp, stage);
            list.Add(item);
        }
    }

    public override void OnClose()
    {
        list.ForEach(item => item.Release());
        list.Clear();
        UICommonEvent.Send("resume_main_ui");
    }

    void OnClickCreate(PointerEventData eventData)
    {
        UIManager.Instance.OpenUI<UI_CreateStage>("UI/UI_CreateStage");
    }
}