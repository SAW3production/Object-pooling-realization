using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public List<Pool> pools;
    public ObjectPooler Instance;



    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + " doesn't exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
    public GameObject SpawnFromPool(string tag, Vector3 position) // POLYMORPHISM
    {
        if (poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + " doesn't exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = Quaternion.Euler(Vector3.zero);
        objectToSpawn.SetActive(true);

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
