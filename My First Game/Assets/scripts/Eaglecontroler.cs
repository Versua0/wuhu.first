using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eaglecontroler: MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform top, bottom;
    public float speed;

    public Collider2D Coll;
    private float topy, bottomy;
    private bool up = true;
    void Start()
    {
        Coll.GetComponent<Collider2D>();
        rb.GetComponent<Rigidbody2D>();

        topy = top.position.y;
        bottomy =bottom.position.y;
        Destroy(bottom.gameObject);
        Destroy(bottom.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        movement();

    }
   
  void movement()
    {
        if(up)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            if (transform.position.y > topy)
            {
                up = false;
            }
        }
        
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if(transform.position.y<bottomy)
            {
                up = true;
            }
        }
    }

}
