using System.Collections.Generic;
using System;

static class UICommonEvent
{
    static Dictionary<string, Action> msgMap = new Dictionary<string, Action>();

    public static void Send(string msg)
    {
        if (msgMap.ContainsKey(msg))
            msgMap[msg].Invoke();
    }

    public static void Add(string msg, Action act)
    {
        if (msgMap.ContainsKey(msg))
            msgMap[msg] += act;
        else
        {
            msgMap.Add(msg, act);
        }
    }

    public static void Remove(string msg, Action act)
    {
        if (msgMap.ContainsKey(msg))
        {
            msgMap[msg] -= act;
            if (msgMap[msg] == null)
                msgMap.Remove(msg);
        }
    }
}
