using UnityEngine;
using UnityEngine.UI;
public class playcontrol : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Collider2D coll;

    public float speed, jumpforce;
    public Transform groundCheck;
    public LayerMask ground;
    public int cherry;

    public Text CherryNum;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        Movement();
        SwitchAnim();
       
        
    }
    //�ƶ�
    void Movement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
 
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
            anim.SetFloat("running", Mathf.Abs(horizontalMove));
        }
        //��Ծ
        if (Input.GetButton("Jump")&& coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            anim.SetBool("jumping", true);
        }
        //��ֹ
        if(horizontalMove==0)
        {
            anim.SetFloat("running",0 );
        }
    }
    //�л�����
    void SwitchAnim()
    {
        anim.SetBool("idling", true);

        if (!anim.GetBool("jumping"))
        {
            if (coll.IsTouchingLayers(ground))
            {
                anim.SetBool("falling", false);
                anim.SetBool("idling", true);
            }
        }
        else
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }

    }
    
    //�ռ���Ʒ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collection")
        {
            Destroy(collision.gameObject);
            cherry += 1;
            CherryNum.text = cherry.ToString();
        }
    }

    //����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(anim.GetBool("falling"))
        {
            if(collision.gameObject.tag== "Enemies")
            {
                Destroy(collision.gameObject);
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                anim.SetBool("jumping", true);
            }
        }
    }


}
