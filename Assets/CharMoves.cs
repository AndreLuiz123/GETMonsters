using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMoves : MonoBehaviour {

    //public CharacterController2D controller;

    //float horizontalMove = 0f;

    //public List<int> moveList;

    //PULO
    public bool onGround;
    public bool isCrouch;
    public bool shieldOn;
    public Transform groundCheck;
    public float jumpForce;
    public float runSpeed;
    public float fallSpeed;
    float verticalMove;



    public Rigidbody2D rb;
    public Animator anim;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //moveList = new List<int>();
        float verticalMove = Input.GetAxisRaw("Vertical");
        bool onGround = true;
        bool isCrouch = false;
        bool shieldOn = false;
        anim.SetBool("onGround",true);
        anim.SetBool("isCrouch",false);
        anim.SetBool("shieldOn",false);
    }

    // Update is called once per frame
    void Update ()
    {

        onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if(!shieldOn)
        {

            //MOVIMENTAÇÃO
            float horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
            verticalMove = Input.GetAxisRaw("Vertical");
            rb.velocity= new Vector2(horizontalMove, rb.velocity.y);


            //PULO
            rb.velocity += Physics2D.gravity*Time.deltaTime;

        if(!onGround)
        {
            anim.SetBool("onGround",false);
            if(rb.velocity.y<0)
            {
                rb.velocity +=  fallSpeed*Physics2D.gravity*Time.deltaTime;
            }

        }else
        {
            anim.SetBool("onGround",true);
            //rb.velocity = new Vector2(horizontalMove, 0);
            if(Input.GetButton("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        //AGACHAR

        if(verticalMove<0 && onGround)
        {
            anim.SetBool("isCrouch",true);
        }else
        {
            anim.SetBool("isCrouch",false);
        }
    }

        //DEFENDER

        if(Input.GetKey(KeyCode.Z))
        {
            shieldOn = true;
            anim.SetBool("shieldOn",true);
            Debug.Log("TESTE");
        }else
        {
            shieldOn = false;
            anim.SetBool("shieldOn",false);
        }

    }

    void Move()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        rb.velocity= new Vector2(horizontalMove, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity += Physics2D.gravity*Time.deltaTime;

        if(!onGround)
        {
            if(rb.velocity.y<0)
            {
                rb.velocity +=  fallSpeed*Physics2D.gravity*Time.deltaTime;
            }

        }else
        {
            //rb.velocity = new Vector2(horizontalMove, 0);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void Crouch()
    {
        if(verticalMove<0 && onGround)
        {
            isCrouch = true;
        }else
        {
            isCrouch = false;
        }
    }

    void Shield()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            shieldOn = true;
        }else
        {
            shieldOn = false;
        }
    }

}
