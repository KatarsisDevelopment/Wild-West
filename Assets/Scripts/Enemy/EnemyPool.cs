using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    Queue<GameObject> EnemyQueue = new Queue<GameObject>();
    public int EnemyCount;
    public GameObject EnemyObj;
    private void Awake()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            GameObject obj = Instantiate(EnemyObj);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            EnemyQueue.Enqueue(obj);
        }

    }
    public GameObject GetPooledObject()
    {
        GameObject obj = EnemyQueue.Dequeue();
        obj.SetActive(true);
        EnemyQueue.Enqueue(obj);
        return obj;
    }
}



