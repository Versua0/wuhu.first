using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Enemy
{
    public Rigidbody2D rb;
    public Transform leftpoint, rightpoint;
    //public Animator Anim;
    public float speed,jumpforce;
    public LayerMask Ground;
    public Collider2D Coll;
    private float leftx, rightx;
    private bool Faceleft = true;
    protected override void Start()
    {
        base.Start();
        Coll.GetComponent<Collider2D>();
       // Anim.GetComponent<Animator>();
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
        Switch();
        
    }
    void Movement()
    {
        if (Faceleft)
        {  if (Coll.IsTouchingLayers(Ground))
            {
                Anim.SetBool("jumping", true);
                rb.velocity = new Vector2(-speed, jumpforce);
            }
                if (transform.position.x < leftx)
                {

                    transform.localScale = new Vector3(-1, 1, 1);
                    Faceleft = false;
                }
            
        }
        else
        {
            if (Coll.IsTouchingLayers(Ground))
            {
                Anim.SetBool("jumping", true);
                rb.velocity = new Vector2(speed, jumpforce);
            }
            if (transform.position.x > rightx)
            {

                transform.localScale = new Vector3(1, 1, 1);
                Faceleft = true;
            }
        }
    }
    void Switch()
        {
        if(Anim.GetBool("jumping"))
        {
            if(rb.velocity.y<0.1)
            {
                Anim.SetBool("jumping", false);
                Anim.SetBool("falling", true);
            }
        }
        if(Coll.IsTouchingLayers(Ground)&&Anim.GetBool("falling"))
        {
            Anim.SetBool("falling", false);
            Anim.SetBool("idle", true);
        }
        }
    public void death()
    {
        Destroy(gameObject);
    }
    public void JumpOn()
    {

        Anim.SetTrigger("death");
    }
}
