using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileService : MonoBehaviour 
{
    /* 获取外部读写目录 */
	public string GetExternalRootDirectory()
    {
        #if UNITY_EDITOR
            return Application.dataPath + "/../";
        #elif UNITY_ANDROID
        #endif
    }
}
