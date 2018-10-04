using UnityEngine;
using UnityEngine.UI;

class UI_BlockEdit : GameUI
{
    TerrainBlock block;

    public override void OnLoaded()
    {
        Find<Button>("board/close").onClick.AddListener(Close);
    }

    public override void OnOpen(params object[] args)
    {
        block = args[0] as TerrainBlock;

    }
}
