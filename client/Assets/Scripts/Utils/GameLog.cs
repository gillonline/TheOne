using UnityEngine;

public class GameLog
{
    public static void Warning(string fmt)
    {
        Debug.LogWarning(fmt);
    }

    public static void WarningFmt(string fmt, params object[] args)
    {
        Debug.LogWarningFormat(fmt, args);
    }
}
