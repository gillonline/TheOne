using UnityEngine;

public class Block
{
    public BlockConfig config;
    public GameObject gameobj;

    public string ResPath
    {
        get
        {
            var cfg = TerrainBlockEditorManager.Instance.FindBlockConfig(config.resID);
            return cfg.res;
        }
    }

    public Block(BlockConfig config)
    {
        this.config = config;
    }

    public void SetGameObject(GameObject obj)
    {
        gameobj = obj;
    }

    public void SetSelectState(bool enable)
    {
        if (enable)
        {
            UIManager.Instance.OpenUI<UI_TerrainBlock>("UI/UI_TerrainBlock", gameobj.transform.position);
        }
        else
        {
            var ui = UIManager.Instance.GetUI<UI_TerrainBlock>("UI/UI_TerrainBlock");
            if (ui != null)
                ui.Close();
        }
    }
}