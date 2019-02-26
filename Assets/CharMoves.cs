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
    public bool isFlying;
    public Transform groundCheck;
    public float jumpForce;
    public float runSpeed;
    public float fallSpeed;

    public Rigidbody2D rigidbody;
    public Animator anim;
    private Monster monster;

    // Use this for initialization
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        monster = GetComponent<Monster>();
        //moveList = new List<int>();
        bool onGround = true;
        bool isCrouch = false;
        bool shieldOn = false;
        bool isFlying = false;
        anim.SetBool("onGround",true);
        anim.SetBool("isCrouch",false);
        anim.SetBool("shieldOn",false);
    }

    // Update is called once per frame
    void Update ()
    {

        onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));



        float horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        float verticalMove = Input.GetAxisRaw("Vertical");
        float verticalMovimentation;

        if(!isFlying)
        {
            verticalMovimentation = rigidbody.velocity.y;
        }else
        {
            verticalMovimentation = Input.GetAxisRaw("Vertical")*runSpeed;
        }


        //MOVIMENTAÇÃO
        Move(horizontalMove, verticalMovimentation);

        //PULO
        if(rigidbody.velocity.y>0)
        {
            rigidbody.velocity += Physics2D.gravity*Time.deltaTime;
        }else
        {
            if(isFlying)
            {
                rigidbody.velocity +=  Physics2D.gravity*Time.deltaTime*0;
            }else
            {
                rigidbody.velocity +=  fallSpeed*Physics2D.gravity*Time.deltaTime;
            }
        }

        //rigidbody.velocity = new Vector2(horizontalMove, 0);
        isFlying = false;
        if(Input.GetButton("Jump"))
        {
            if(onGround)
            {
                Jump();
            }
        }

        //AGACHAR
        isCrouch = false;
        if(verticalMove<0)
        {
            Crouch();
        }

        //DEFENDER
        shieldOn = false;
        if(Input.GetKey(KeyCode.Z))
        {
            Shield();
        }
        if(shieldOn){
            Debug.Log("TESTE");
        }

        //VOAR
        isFlying = false;
        if(Input.GetKey(KeyCode.X)){
            Fly();
        }


        anim.SetBool("onGround", onGround);
        anim.SetBool("isCrouch",isCrouch);
        anim.SetBool("shieldOn",shieldOn);
    }

    void Move(float horizontalMove, float verticalMove)
    {
        if(!shieldOn)
        {
            rigidbody.velocity = new Vector2(horizontalMove, verticalMove);
        }
    }

    void Jump()
    {
        if(onGround && !shieldOn)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
    }

    void Crouch()
    {
        if(onGround && !shieldOn)
        {
            isCrouch = true;
        }
    }

    void Shield()
    {
        if(monster.shield>=0 && onGround && !isCrouch)
        {
            if(rigidbody.velocity != new Vector2(0,0))
            {
                rigidbody.velocity = new Vector2(0,0);
            }
                shieldOn = true;
        }
    }

    void Fly(){
        if(monster.energy>0 && !onGround)
        {
            isFlying = true;
        }
    }

}
