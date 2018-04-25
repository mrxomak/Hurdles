using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 5f;
    public float acceleration = 1f;
    public float jumpForce = 250f;
    public float jumpingCooldown = 0.6f;

    public bool reachedFinishLine = false;

    private float speed = 0f;
    private float jumpingTimer = 0f;

    private void Start()
    {
        
    }

    private void Update()
    {
        speed += acceleration * Time.deltaTime;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        transform.position += Vector3.forward * speed * Time.deltaTime;

        jumpingTimer -= Time.deltaTime;
        if (Input.GetKeyDown("space") && jumpingTimer <= 0f)
        {
            jumpingTimer = jumpingCooldown;
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Obsticle")
        {
            speed *= 0.25f;
        }

        if (collider.tag == "FinishLine")
        {
            reachedFinishLine = true;
        }
    }
}
