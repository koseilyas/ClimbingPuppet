
using UnityEngine;

public static class Log
{
    private static bool _enabled = true;

    public static void Write(string log)
    {
        if (_enabled)
        {
            Debug.Log(log);
        }
    }
}
