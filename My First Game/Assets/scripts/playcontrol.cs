using UnityEngine;
using UnityEngine.UI;
public class playcontrol : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public Collider2D coll;

    public float speed, jumpforce;
    public Transform groundCheck;
    public LayerMask ground;
    public int cherry;
    private bool ishurt;//默认为false

    public Text CherryNum;


    // Start is called before the first frame update
     void  Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (!ishurt)
        {
            Movement();
        }
        SwitchAnim();
       
    }
    //移动
    void Movement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
 
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
            anim.SetFloat("running", Mathf.Abs(horizontalMove));
        }
        //跳跃
        if (Input.GetButton("Jump")&& coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            anim.SetBool("jumping", true);
        }
        //静止
        if(horizontalMove==0)
        {
            anim.SetFloat("running",0 );
        }
        Couching();
    }
    //切换动画
    void SwitchAnim()
    {
        anim.SetBool("idling", true);
        if(rb.velocity.y<0.1f&&!coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", true);         
        }
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
            
        }
        else if(ishurt)
        {
            anim.SetBool("hurt", true);
            anim.SetFloat("running", 0);
            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                anim.SetBool("hurt", false);
                anim.SetBool("idling", true);
                ishurt = false;
            }
        }
        else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idling", true);
        }


    }
    
    //收集物品
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collection")
        {
            Destroy(collision.gameObject);
            cherry += 1;
            CherryNum.text = cherry.ToString();
        }
    }

    //敌人
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemies")
        {
            Enemies enemy = collision.gameObject.GetComponent<Enemies>();
            if (anim.GetBool("falling"))
            {
                enemy.JumpOn();
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                anim.SetBool("jumping", true);
            }
            else if(transform.position.x<collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
                ishurt = true;
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
                ishurt = true;
            }
        }
        
    }

    void Couching()
    {
        if (Input.GetButtonDown("Couch"))
        {
            anim.SetBool("Couching", true);
        }
        else if (Input.GetButtonUp("Couch"))
        {
            anim.SetBool("Couching", true);
        }
    }
}
