class GameSceneCreateStage : GameScene
{
    UI_EditStage edit_main;
    StageTerrain terrain;
    
    public GameSceneCreateStage() : base()
    {
        name = "CreateStage";
    }

    public override void OnEnter(params object[] args)
    {
        var stageconfig = args[0] as StageConfig;
        if (stageconfig != null)
        {
            terrain = StageTerrain.Create(stageconfig.width, stageconfig.height);
            terrain.Load();

            edit_main = UIManager.Instance.OpenUI<UI_EditStage>("UI/UI_EditStage", terrain);
        }
    }
}
