using System;
using System.Reflection;
using UnityEngine;

public static class DelegateUtils
{
    public static void ListSubscribedMethods(Delegate del)
    {
        if (del == null)
        {
            Debug.Log("None Method Founded");
            return;
        }

        Delegate[] invocationList = del.GetInvocationList();
        foreach (Delegate d in invocationList)
        {
            MethodInfo methodInfo = d.Method;
            string methodName = methodInfo.Name;
            string declaringType = methodInfo.DeclaringType.FullName;
            Debug.Log($"Suscribed Method/s: {declaringType}.{methodName}");
        }
    }
}
