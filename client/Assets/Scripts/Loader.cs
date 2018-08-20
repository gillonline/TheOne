using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class Loader : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Debug.Log(Application.dataPath);
        LuaLoader.StartLua();
    }
}
