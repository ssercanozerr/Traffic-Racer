using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    [Serializable]
    private struct Pool
    {
        public Queue<GameObject> pooledObjects;
        public GameObject objectPrefab;
        public int poolSize;
    }

    [SerializeField] private Pool[] pools;

    private void Awake()
    {
        CreateObjectPool();
    }

    public GameObject OnGetObjectFromPool<T>(T entityType) where T : Enum
    {
        int entityTypeIndex = Convert.ToInt32(entityType);
        if (pools[entityTypeIndex].pooledObjects == null || pools[entityTypeIndex].pooledObjects.Count == 0)
        {
            return null;
        }

        GameObject obj = pools[entityTypeIndex].pooledObjects.Dequeue();
        obj.SetActive(true);
        pools[entityTypeIndex].pooledObjects.Enqueue(obj);

        return obj;
    }


    private void CreateObjectPool()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i].pooledObjects = new Queue<GameObject>();

            for (int j = 0; j < pools[i].poolSize; j++)
            {
                GameObject obj = Instantiate(pools[i].objectPrefab);
                obj.SetActive(false);
                pools[i].pooledObjects.Enqueue(obj);
            }
        }
    }
}
