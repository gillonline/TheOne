using UnityEngine;

public class TerrainBlock
{
    public int id;
    public bool couldWalk;

    public GameObject gameobj;
    public Material mat;
    public Color originCol;

    public void SetGameObject(GameObject obj)
    {
        gameobj = obj;
        //mat = gameobj.GetComponentInChildren<Renderer>().material;
        //originCol = mat.color;
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