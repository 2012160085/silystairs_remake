using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver
{
    List<GameObject> inActiveObjs;
    List<GameObject> activeObjs;
    GameObject prefab;
    public void Initiate(string name,GameObject prefab, int maxNum)
    {
        GameObject parent = new GameObject(name);
        inActiveObjs = new List<GameObject>();
        activeObjs = new List<GameObject>();
        for (int i = 0; i < maxNum; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.SetActive(false);
            obj.transform.SetParent(parent.transform);
            inActiveObjs.Add(obj);
        }
    }
    public GameObject LoadObject()
    {
        if (inActiveObjs.Count == 0)
        {
            GameObject obj = activeObjs[0];
            activeObjs.RemoveAt(0);
            activeObjs.Add(obj);
            return obj;
        }
        else
        {
            GameObject obj = inActiveObjs[0];
            obj.SetActive(true);
            inActiveObjs.RemoveAt(0);
            activeObjs.Add(obj);
            return obj;
        }
    }
    public void ReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
        inActiveObjs.Add(obj);
    }
}
