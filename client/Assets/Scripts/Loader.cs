using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

class Loader : MonoBehaviour
{
    void Start()
    {
        FileService.Instance.Init();
        MediaService.Instance.Init();
        NetworkService.Instance.Init();

        GameSceneManager.Instance.Init();
        StageManager.Instance.Init();
        StageEditorManager.Instance.Init();

        GameSceneManager.Instance.SwitchScene("Hall");
        //Debug.Log(Application.dataPath);
        //LuaLoader.StartLua(); 
    }
}
