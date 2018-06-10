using System.Collections;
using UnityEngine;

public static class GameObjectExtensions
{
    public static void DestroyWithAction(this MonoBehaviour host, Object obj, float time, System.Action function)
    {
        host.StartCoroutine(ExecuteAction(obj, time, function));
    }

    private static IEnumerator ExecuteAction(Object obj, float time, System.Action function)
    {
        yield return new WaitForSeconds(time);
        if (obj != null)
        {
            function();
            Object.Destroy(obj);
        }
        yield return null;
    }
}
