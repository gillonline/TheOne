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

        GameSceneManager.Instance.SwitchScene("Start");
        //Debug.Log(Application.dataPath);
        //LuaLoader.StartLua();
    }
}
