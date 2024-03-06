using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPooler Instance;

    public void Awake()
    {
        Instance = this;
    }


    public GameObject SpawnFromPool(string tagName, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tagName))
        {
            return null;
        }

        var objectToSpawn = poolDictionary[tagName].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        
        poolDictionary[tagName].Enqueue(objectToSpawn);
        
        return objectToSpawn;
    }

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        foreach (var pool in pools)
        {
            var objectPool = new Queue<GameObject>();

            for (var i = 0; i < pool.size; i++)
            {
                var gameObj = Instantiate(pool.prefab);
                gameObj.SetActive(false);
                objectPool.Enqueue(gameObj);
            }
            
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
}
