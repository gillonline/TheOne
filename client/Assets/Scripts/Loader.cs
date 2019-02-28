using UnityEngine;

class Loader : MonoBehaviour
{
    void Start()
    {
        FileService.Instance.Init();
        MediaService.Instance.Init();
        NetworkService.Instance.Init();

        GameSceneManager.Instance.Init();
        StageConfigManager.Instance.Init();
        StageEditorManager.Instance.Init();

        GameSceneManager.Instance.SwitchScene("Hall");
        //Debug.Log(Application.dataPath);
        //LuaLoader.StartLua(); 
    }

    private void FixedUpdate()
    {
        GameSceneManager.Instance.Update();
    }

    private void Update()
    {

    }
}
