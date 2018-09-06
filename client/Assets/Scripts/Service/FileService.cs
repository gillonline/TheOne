using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class FileService : SingletonService<FileService> 
{
    /* 获取外部读写目录 */
	public string GetExternalRootDirectory()
    {
        #if UNITY_EDITOR
            return Application.dataPath + "/../../build/game_resource";
        #elif UNITY_ANDROID
        #endif
    }
}
