using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMoves : MonoBehaviour {

	//public CharacterController2D controller;

	//float horizontalMove = 0f;

	public List<int> moveList;

	//PULO
	public bool onGround = false;
	public Transform groundCheck;
	public float jumpForce;
	public float runSpeed;
	public float fallSpeed;


	public Rigidbody2D rb;


	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		moveList = new List<int>();

	}

	// Update is called once per frame
	void Update ()
	{

		onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		//MOVIMENTAÇÃO
		float horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
		rb.velocity= new Vector2(horizontalMove, rb.velocity.y);


		//PULO
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
			if(Input.GetButton("Jump"))
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			}
		}



	}


}
