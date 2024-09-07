using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float distance;
    public float time;
    public Rigidbody rb;
    public Vector3 acceleration;
    public Vector3 lastVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastVelocity = rb.velocity;
    }

    void FixedUpdate()
    {
        time = distance / speed;

        Vector3 currentVelocity = rb.velocity;
        acceleration = (currentVelocity - lastVelocity) / Time.fixedDeltaTime;
        lastVelocity = currentVelocity;

        Vector3 moveDirection = (target.position - transform.position).normalized;
        rb.velocity = moveDirection * speed;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}