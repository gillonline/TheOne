using System.Collections.Generic;

class GameSceneManager : SingletonManager<GameSceneManager>
{
    GameScene currentScene;
    List<GameScene> sceneList = new List<GameScene>();

    public override void Init()
    {
        sceneList.Add(new GameSceneStart());
        sceneList.Add(new GameSceneHall());
        sceneList.Add(new GameSceneCreateStage());
    }

    public void SwitchScene(string sceneName, params object[] args)
    {
        var tarScene = sceneList.Find(item => item.name == sceneName);
        if (tarScene != null)
        {
            UIManager.Instance.CloseAll();
            if (currentScene != null)
            {
                currentScene.OnLeave();
                currentScene = null;
            }

            currentScene = tarScene;
            currentScene.OnEnter(args);
        }
    }
}