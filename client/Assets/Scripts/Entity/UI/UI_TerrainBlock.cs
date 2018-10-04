using UnityEngine;

class UI_TerrainBlock : GameUI
{
    public override void OnOpen(params object[] args)
    {
        var pos = (Vector3)args[0];
        SetPosition(pos.x, pos.z);
    }

    public void SetPosition(float x, float z)
    {
        var pos = root.position;
        pos.x = x;
        pos.z = z;
        root.position = pos;
    }
}
