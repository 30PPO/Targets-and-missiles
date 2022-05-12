using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects <T> where T: MonoBehaviour
{
    public T prefab;
    public bool autoExpand;
    public Transform container;

    private List<T> pool;

    public PoolObjects(T prefab, int count) 
    {
        this.prefab = prefab;
        this.container = new GameObject("Container").transform;
        CreatePool(count);
    }

    public PoolObjects(T prefab, int count,Transform container)
    {
        this.prefab = prefab;
        this.container = container;
        CreatePool(count);
    }

    private void CreatePool(int count) 
    {
        this.pool = new List<T>();

        for (int i = 0; i < count; i++) 
        {
            CreateObject();
        }
    
    }

    private T CreateObject(bool isActiveByDefault = false) 
    {
        var createdObject = Object.Instantiate(prefab,container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element) 
    {
        foreach (var elem in pool) 
        {
            if (!elem.gameObject.activeInHierarchy) 
            {
                element = elem;
                elem.gameObject.SetActive(true);
                return true;

            }
        }  

        element = null;
        return false;   
    }

    public T GetFreeElement() 
    {
        if(HasFreeElement(out var element))
            return element;
        else if(autoExpand)
            return CreateObject(true);

        throw new System.Exception($"There is no free element in pool of type {typeof(T)}");
    }


}
