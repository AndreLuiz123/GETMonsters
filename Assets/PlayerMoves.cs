using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour {
	public List<StatusEffect> status; 

	public float speed;
	public float jumpForce;

	private Rigidbody2D rb;
	private bool facingRight = true;
	private bool jump = false;
	public bool onGround = false;
	public Transform groundCheck;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		//groundCheck = gameObject.transform.Find("groundCheck");
	}

	// Update is called once per frame
	void Update () {
		onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if(Input.GetButtonDown("Jump") && onGround){
			jump = true;
		}
	}

	void FixedUpdate(){

		float h = Input.GetAxisRaw("Horizontal");

		rb.velocity = new Vector2(h*speed, rb.velocity.y);


	}
}
