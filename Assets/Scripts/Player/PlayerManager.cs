using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float SpeedMove = 3f;
    Camera MCamera;
    Animator Animator;
    [SerializeField] private FloatingJoystick FloatingJoystick;
    public GameManager GameManager;
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        MCamera = Camera.main;
    }
    void Update()
    {
        if (GameManager.IsGameOver==false)
        {
            Move();
        }
    }
    private void LateUpdate()
    {
        CameraFollow();
    }
    void Move()
    {
        float Hor =  FloatingJoystick.Horizontal * Time.deltaTime * SpeedMove;
        float MoveCount = Mathf.Clamp(transform.position.x + Hor, -5, 5);
        transform.position = new Vector3(MoveCount, 0, 0);
        if (Hor != 0)
        {
            Animator.SetBool("IsMove", true);
        }
        else
        {
            Animator.SetBool("IsMove", false);
        }
    }
    void CameraFollow()
    {
        MCamera.transform.position = transform.position + new Vector3(0, 5, -3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stick"))
        {
            GameManager.BaseHP = 0;
            Debug.Log("Over");
        }
    }
}
