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

    public GameObject OnGetObjectFromPool(EntityTypes entityType)
    {
        if (pools[(int)entityType].pooledObjects == null || pools[(int)entityType].pooledObjects.Count == 0)
        {
            return null;
        }

        GameObject obj = pools[(int)entityType].pooledObjects.Dequeue();
        obj.SetActive(true);
        pools[(int)entityType].pooledObjects.Enqueue(obj);

        return obj;
    }
}
