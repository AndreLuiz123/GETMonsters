using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Renderer renderer;
    public float x, y;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        rigidbody.velocity = new Vector2 (x, y);

        if (!renderer.isVisible)
            Destroy(gameObject);
            
    }

    public void setDirection (float direction)
    {
        transform.localScale =  new Vector3(direction, 1f, 1f);
        x *= direction;
        y *= direction;
    }
}
