using System.Collections.Generic;
using UnityEngine;

public class Spawner : Mono
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObj;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPrefabs();
        LoadHolder();
    }

    protected void LoadPrefabs()
    {
        if(prefabs.Count > 0) return;

        Transform prefabObjs = transform.Find("Prefabs");

        foreach(Transform prefabObj in prefabObjs)
        {
            prefabs.Add(prefabObj);
        }

        HidePrefabs();
    }

    protected void HidePrefabs()
    {
        foreach(Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    protected void LoadHolder()
    {
        if(holder != null) return;

        holder = transform.Find("Holder");
    }

    public Transform Spawn(Transform preFab, Vector3 pos, Quaternion rot)
    {
        Transform prefab = GetPrefabByName(preFab);

        if(prefab == null) Debug.LogWarning("Can't find the prefab: " + preFab.name);

        Transform newPrefab = GetObjectFromPool(prefab);
        
        newPrefab.SetPositionAndRotation(pos, rot);

        return newPrefab;
    }

    protected Transform GetPrefabByName(Transform preFab)
    {
        foreach(Transform prefab in prefabs)
        {
            if(preFab.name == prefab.name)  return prefab;
        }

        return null;
    }

    protected Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform obj in poolObj)
        {
            if(obj == null) continue;

            if(obj.name == prefab.name)
            {
                poolObj.Remove(obj);
                return obj;
            }
        }

        Transform newObj = Instantiate(prefab);
        newObj.name = prefab.name;

        newObj.SetParent(holder);

        return newObj;
    }

    public void Despawn(Transform obj)
    {
        if(poolObj.Contains(obj)) return;

        poolObj.Add(obj);
        obj.gameObject.SetActive(false);
    }
}