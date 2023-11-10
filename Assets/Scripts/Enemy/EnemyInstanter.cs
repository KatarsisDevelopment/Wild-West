using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstanter : MonoBehaviour
{
    public float InstanceSpeed = 1f;
    public Transform EnenmyInstantPos;
    public EnemyPool EnemyPool;
    void Start()
    {
        StartCoroutine(EnemyInstantEnum());
        InvokeRepeating(nameof(InstanceFast),30f, 60f);
    }
    IEnumerator EnemyInstantEnum()
    {
        while (true)
        {
            if (GameManager.IsGameOver == false)
            {
                var Enemy = EnemyPool.GetPooledObject();
                Enemy.transform.position = new Vector3(Random.Range(-4, 4), 1, EnenmyInstantPos.position.z);
            }
                yield return new WaitForSeconds(InstanceSpeed);
        }
    }
    void InstanceFast()
    {
        if (InstanceSpeed > 0)
        {
            InstanceSpeed -= 0.1f;
        }
    }
}
