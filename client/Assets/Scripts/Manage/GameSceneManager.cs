using System.Collections.Generic;

class GameSceneManager : SingletonManager<GameSceneManager>
{
    GameScene currentScene;
    List<GameScene> sceneList = new List<GameScene>();

    public override void Init()
    {
        sceneList.Add(new GameSceneStart());
    }

    public void SwitchScene(string sceneName)
    {
        var tarScene = sceneList.Find(item => item.name == sceneName);
        if (tarScene != null)
        {
            if (currentScene != null)
            {
                currentScene.OnLeave();
                currentScene = null;
            }

            currentScene = tarScene;
            currentScene.OnEnter();
        }
    }
}