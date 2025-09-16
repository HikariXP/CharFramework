/*
 * Author: CharSui
 * Created On: 2025.09.16
 * Description: 日志记录器，提供日志记录功能
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class CharLogger
{
    public static void Log(object message,
        [CallerMemberName] string methodName = "",
        [CallerFilePath] string filePath = "")
    {
        string className = System.IO.Path.GetFileNameWithoutExtension(filePath);
        Debug.Log($"[{className}.{methodName}] {message}");
    }

    public static void LogError(object message,
        [CallerMemberName] string methodName = "",
        [CallerFilePath] string filePath = "")
    {
        string className = System.IO.Path.GetFileNameWithoutExtension(filePath);
        Debug.LogError($"[{className}.{methodName}] {message}");
    }
}
