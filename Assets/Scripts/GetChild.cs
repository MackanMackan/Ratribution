using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GetChild
{
    public static List<GameObject> GetChildren(this GameObject go)
    {
        List<GameObject> children = new List<GameObject>();

        foreach (Transform tran in go.GetComponentInChildren<Transform>())
        {
            if (tran == go.transform) continue;
            children.Add(tran.gameObject);
        }
        return children;
    }

}