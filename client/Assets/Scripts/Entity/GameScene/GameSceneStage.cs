using System.Xml;

class GameSceneStage : GameScene
{
    public Stage currentStage;
    public FrameController frameController;

    public GameSceneStage() : base()
    {
        name = "Stage";
    }

    public override void OnEnter(params object[] args)
    {
        var config = args[0] as XmlNode;
        if (config != null)
        {
            currentStage = new Stage(config);
        }

        frameController = new FrameController();
        frameController.stage = currentStage;
    }

    public override void OnUpdate()
    {
        frameController.Update();
    }

    public override void OnRenderUpdate()
    {
        frameController.RenderUpdate();
    }
}
