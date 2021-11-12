using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform leftpoint, rightpoint;
    public float speed;
    private float leftx, rightx;
    private bool Faceleft=true;
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (Faceleft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < leftx)
            {
                
                transform.localScale = new Vector3(-1, 1, 1);
                Faceleft = false;
            }

        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > rightx)
            {
                
                transform.localScale = new Vector3(1, 1, 1);
                Faceleft = true;
            }
        }
    }

}
