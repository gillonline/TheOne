class StageEditorManager : SingletonManager<StageEditorManager>
{
    public override void Init()
    {
        TerrainBlockEditorManager.Instance.Init();
    }
}
