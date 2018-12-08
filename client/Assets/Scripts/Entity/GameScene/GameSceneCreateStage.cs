class GameSceneCreateStage : GameScene
{
    UI_EditStage edit_main;
    Stage stage;
    
    public GameSceneCreateStage() : base()
    {
        name = "CreateStage";
    }

    public override void OnEnter(params object[] args)
    {
        var stageconfig = args[0] as StageConfig;
        if (stageconfig != null)
        {
            stage = new Stage(stageconfig);
            stage.Load();

            edit_main = UIManager.Instance.OpenUI<UI_EditStage>("UI/UI_EditStage", stage);
        }
    }
}
