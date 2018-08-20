using XLua;
using UnityEngine;
using System.IO;

class LuaLoader
{
    public static void StartLua()
    {
        var luaEnv = new LuaEnv();
        luaEnv.AddLoader((ref string filePath) =>
        {
            var fileFullPath = string.Format("{0}/{1}.lua", FileService.Instance.GetExternalRootDirectory(), filePath);
            return File.ReadAllBytes(fileFullPath);
        });
        luaEnv.DoString("require 'main'");
    }
}
