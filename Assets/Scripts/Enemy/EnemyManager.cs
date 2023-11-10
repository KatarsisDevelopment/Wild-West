using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    [SerializeField] float SpeedEnemy = 3f;
    private void Start()
    {
    }
    void Update()
    {
        if (GameManager.IsGameOver == false)
        {
            transform.Translate(SpeedEnemy * Time.deltaTime * Vector3.back);
        }
    }
}
