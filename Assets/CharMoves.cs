using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMoves : MonoBehaviour {

	//public CharacterController2D controller;

	//float horizontalMove = 0f;

	public bool onGround = false;
	public Transform groundCheck;


	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));


		float horizontalMove = Input.GetAxisRaw("Horizontal");

		rb.velocity= new Vector2(5*horizontalMove,rb.velocity.y);

		if(onGround){
			rb.AddForce(new Vector2(0, 100));
		}


	}

	void FixedUpdate(){

	}

}
