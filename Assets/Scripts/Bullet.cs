using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;

    public float speed = 5.0f;

    float despawnTime = 3.0f;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        direction = this.GetComponent<Transform>().up;
        rb.velocity = direction * speed;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= despawnTime)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.isTrigger)
        {
            Destroy(this.gameObject);
        }
    }
}
