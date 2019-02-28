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
        if (args[0] is XmlNode config)
        {
            currentStage = new Stage(config);
        }

        frameController = new FrameController
        {
            stage = currentStage
        };
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
