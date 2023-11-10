using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float SpeedBullet,DTime;
     GameManager GameManager;
    TrailRenderer TrailRenderer;
    private void Awake()
    {
        TrailRenderer = GetComponent<TrailRenderer>();
        TrailRenderer.enabled = false;
        GameManager = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        InvokeRepeating(nameof(Disable), 10f, 10f);
        InvokeRepeating(nameof(TrailActive), 0.3f, 0.3f);
    }
    void Update()
    {
        if (GameManager.IsGameOver == false)
        {
            transform.Translate(SpeedBullet * Time.deltaTime * Vector3.forward);
        }
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }
    void TrailActive()
    {
        TrailRenderer.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Score += 1;
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
            
            GameObject effect = EffectPool.instance.GetEffect();
            if (effect != null)
            {
                effect.transform.position = transform.position;
            }
        }
    }

  
}
