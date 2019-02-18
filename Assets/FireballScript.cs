using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{

    public float velX = 0f;
    public float velY = 0f;
    public Rigidbody2D rb;
    public Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (velX, velY);

        if (!renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    public void setPlayerCollider(Collider2D playerCollider)
    {
        Physics2D.IgnoreCollision(playerCollider, GetComponent<BoxCollider2D>(), true);
    }
}
