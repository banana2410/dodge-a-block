using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private T prefab;
    private Queue<T> objects = new Queue<T>();


    #region Singleton
    public static GenericObjectPool<T> Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    #endregion



    public T Get()
    {
        if (objects.Count == 0)
        {
            AddObjects(1);
        }

        return objects.Dequeue();
    }


    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        objects.Enqueue(obj);
    }

    public void AddObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            T newObject = GameObject.Instantiate(prefab);
            newObject.gameObject.SetActive(false);
            objects.Enqueue(newObject);
        }

    }


    void Update()
    {

    }
}
