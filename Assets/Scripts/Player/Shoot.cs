using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform FirePos;
    [SerializeField] float ShootTime = 1f;
    public ParticleSystem UprageEffect,LevelUpEffect;
    private void Awake()
    {
        UprageEffect.Stop();
        LevelUpEffect.Stop();
    }
    void Start()
    {
        StartCoroutine(ShootBullet());
        InvokeRepeating(nameof(IncreaseShoot), 60f, 60f);
    }
    void IncreaseShoot()
    {
        ShootTime /= 2f;
        UprageEffect.Play();
        LevelUpEffect.Play();
    }
    IEnumerator ShootBullet()
    {
        while (true)
        {
            if (GameManager.IsGameOver == false)
            {
                GameObject ýnstantinateObject = BulletPool.instance.GetBullet();
                if (ýnstantinateObject != null)
                {
                    ýnstantinateObject.transform.position = FirePos.transform.position;
                    ýnstantinateObject.SetActive(true);
                }
            }
       
            yield return new WaitForSeconds(ShootTime);
        }
    }
}
