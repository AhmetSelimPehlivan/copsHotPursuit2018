using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    float hInput = 0.0f;
    float vInput = 0.0f;

    public float speed = 1500f;
    public float turnRate = 90f;

    Quaternion targetRotation;

    Transform player;
    private Transform myTransform;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        targetRotation = Quaternion.identity;
        myTransform = transform;
    }


    void Update()
    {
        if (player == null)
            return;
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        hInput = dir.x;
        vInput = dir.z;
    }


    void FixedUpdate()
    {
        Rotation(hInput, vInput);
        Movement(hInput, vInput);
    }

    void Rotation(float horizontal, float vertical)
    {
        float angle = Mathf.Atan2(hInput, vInput) * Mathf.Rad2Deg;
        float step = turnRate * Time.deltaTime;

        targetRotation.eulerAngles = new Vector3(0, angle, 0);
        myTransform.rotation = Quaternion.RotateTowards(myTransform.rotation, targetRotation, step);
    }

    void Movement(float horizontal, float vertical)
    {
        rb.AddForce(myTransform.forward * speed * Time.deltaTime);
    }
}    
