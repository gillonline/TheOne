using UnityEngine;
using System.Xml;

public class Block
{
    public int resID;
    public bool walkable;
    public bool flyable;
    public GameObject gameobj;

    public string ResPath
    {
        get
        {
            var cfg = TerrainBlockEditorManager.Instance.FindBlockConfig(resID);
            return cfg.res;
        }
    }

    public Block(XmlNode node)
    {
        var elem = (XmlElement)node;
        resID = elem.GetInt("resID");
        walkable = elem.GetBool("walkable");
        flyable = elem.GetBool("flyable");
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