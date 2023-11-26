using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();

    public void Initialize()
    {
        GameObject[] objs = Resources.LoadAll<GameObject>("Prefabs/UI");
        
        foreach (GameObject obj in objs) 
        {
            prefabs[obj.name] = obj;
        }
    }

    public GameObject Instantiate(string prefabName)
    {
        if (!prefabs.TryGetValue(prefabName, out GameObject prefab))
        {
            return null;
        }

        return GameObject.Instantiate(prefab);
    }
}
