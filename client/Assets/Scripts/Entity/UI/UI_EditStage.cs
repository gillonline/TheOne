using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

class UI_EditStage : GameUI
{
    Camera cam;
    StageTerrain terrain;
    TerrainBlock currentBlock;

    public override void OnLoaded()
    {
        var touch = Find("touch");
        DragMonitor.AddEvent(touch, OnDrag);
        ClickMonitor.AddEvent(touch, OnClick);
        Find<Button>("back").onClick.AddListener(Close);
        Find<Slider>("zoom").onValueChanged.AddListener(Zoom);
    }

    public override void OnOpen(params object[] args)
    {
        cam = Camera.main;
        terrain = args[0] as StageTerrain;
    }

    void OnDrag(Vector2 offset, float deltaTime)
    {
        var cameraHMax = cam.orthographicSize * 2;
        var cameraWMax = cameraHMax * Screen.currentResolution.width / Screen.currentResolution.height;
        //Debug.LogFormat("offset {0}, time:{1}", offset, deltaTime);
        var xoffset = offset.x * cameraWMax / Screen.currentResolution.width;
        var yoffset = offset.y * cameraHMax / Screen.currentResolution.height;

        cam.transform.position -= new Vector3(xoffset, 0, yoffset);
    }

    void OnClick(PointerEventData eventData)
    {
        var wp = cam.ScreenToWorldPoint(eventData.position);
        var selBlock = terrain.Find(wp.x, wp.z);
        if (currentBlock != null)
            currentBlock.SetSelectState(false);
        if (selBlock != null)
        {
            currentBlock = selBlock;
            currentBlock.SetSelectState(true);
            UIManager.Instance.OpenUI<UI_BlockEdit>("UI/UI_BlockEdit", currentBlock);
        }
    }

    void Zoom(float val)
    {
        cam.orthographicSize = 5 + (val - 0.5f) * 4;
    }
}