using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

class FileService : SingletonService<FileService>
{
    /* 获取外部读写目录 */
    public string GetExternalRootDirectory()
    {
#if UNITY_EDITOR
        return Application.dataPath + "\\..\\game_resource";
#else
        return Application.persistentDataPath + "/game_resource";
#endif
    }

    public string[] GetAllFiles(string path)
    {
        var rootPath = GetExternalRootDirectory();
        var abPath = Path.Combine(rootPath, path);
        if (Directory.Exists(abPath))
        {
            return Directory.GetFiles(abPath);
        }
        else
            return null;
    }

    public byte[] ReadFile(string filePath)
    {
        if (File.Exists(filePath))
            return File.ReadAllBytes(filePath);
        else
            return null;
    }
}
