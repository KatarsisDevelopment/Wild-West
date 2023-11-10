using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour 
{
    public float MoveSpeed = 5f; 
    public float JumpSpeed = 10f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating(nameof(Disabe), 15f, 15f);
    }
    private void FixedUpdate()
    {
        Vector3 hareket = new Vector3(0f, 0f, -1f) * MoveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + hareket);
    }
    void Disabe()
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.AddForce(Vector3.up * JumpSpeed, ForceMode.Impulse);
        }
    }
}
