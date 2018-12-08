using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

class UI_BlockEdit : GameUI
{

    class Item
    {
        public TerrainBlockEditorManager.BlockResConfig config;
        public Transform clone;

        public Item(Transform tmp, TerrainBlockEditorManager.BlockResConfig config)
        {
            clone = tmp.Clone();
            this.config = config;
            clone.Find<Text>("name").text = config.name;
            clone.Find<Toggle>().isOn = false;
        }

        public void SetOn(bool enable)
        {
            clone.Find<Toggle>().isOn = enable;
        }
    }

    Block block;
    List<Item> blockTypeList = new List<Item>();

    public override void OnLoaded()
    {
        Find<Button>("board/close").onClick.AddListener(Close);

        var tmp = Find("board/list/Viewport/Content/item");
        var typeList = TerrainBlockEditorManager.Instance.blockList;
        foreach (var item in typeList)
        {
            blockTypeList.Add(new Item(tmp, item));
        }
        tmp.gameObject.SetActive(false);
    }

    public override void OnOpen(params object[] args)
    {
        block = args[0] as Block;
        foreach (var item in blockTypeList)
        {
            if (block.config.resID == item.config.id)
            {
                item.SetOn(true);
                break;
            }
        }
    }
}
