using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] int generateOnAwake = 20;
    [SerializeField] int generateOnEmpty = 10;
    [SerializeField] Poolable[] objectPrefabs;
    Poolable[] objects;
    Queue<Poolable> pool = new Queue<Poolable>();
    private void Awake()
    {
        GenerateObjects(generateOnAwake);
    }
    public Poolable GetObject()
    {
        if(pool.Count == 0)
        {
            GenerateObjects(generateOnEmpty);
        }
        return pool.Dequeue();
    }

    public void AddObject(Poolable obj)
    {
        obj.gameObject.SetActive(false);
        obj.pool = this;
        pool.Enqueue(obj);
    }

    Poolable GetRandomObject()
    {
        int r = Random.Range(0, objectPrefabs.Length);
        return objectPrefabs[r];
    }

    void GenerateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(GetRandomObject(), transform);
            AddObject(obj);
        }
    }    
}
