using XLua;
using UnityEngine;

class LuaLoader
{
    public static void StartLua()
    {
        var luaEnv = new LuaEnv();
        // luaEnv.AddLoader((ref string filePath) =>
        // {

        // });
        luaEnv.LoadString("require 'main'");
    }
}
