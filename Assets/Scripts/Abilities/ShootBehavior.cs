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
        rigidbody.velocity = new Vector2 (x, y);
    }

    void Update()
    {
        if (!renderer.isVisible)
            Destroy(gameObject);
    }

    public void SetDirection(float direction)
    {
        transform.localScale = new Vector3(direction, 1f, 1f);
        x = Mathf.Abs(x) * direction;
    }
}
