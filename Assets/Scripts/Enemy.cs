using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform tr;
    Rigidbody2D rb;
    public GameObject bullet;
    Transform player;

    public float timeReq = 3.0f;
    float timeDiff;

    public float speed = 5.0f;

    public int type = 0;

    // Start is called before the first frame update
    void Start()
    {
        tr = this.GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();

        player = GameObject.Find("Player").GetComponent<Transform>();

        timeDiff = Random.Range(0.0f, timeReq - 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timeDiff += Time.deltaTime;

        float distance = (player.position - tr.position).magnitude;
        Vector2 direction = (player.position - tr.position).normalized;

        if ((player.position.x - tr.position.x) < 23 && (player.position.x - tr.position.x) > -23 && (player.position.y - tr.position.y) < 10 && (player.position.x - tr.position.x) > -10)
        {
            tr.rotation = Quaternion.LookRotation(Vector3.back, player.position - tr.position);

            if (type == 1)
            {
                if (distance > 3)
                {
                    rb.velocity = direction * speed;
                }

            }
            else if (type == 2)
            {
                rb.velocity = new Vector2(-direction.y, direction.x) * speed;

                if (distance > 7)
                {
                    rb.velocity += direction * speed / 2;
                }
                else if (distance < 5)
                {
                    rb.velocity -= direction * speed / 2;
                }
            }

            if (timeDiff >= timeReq)
            {
                timeDiff = 0.0f;

                // Makes it shoot bad lol
                Vector3 noise = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f), 0.0f);
                tr.rotation = Quaternion.LookRotation(Vector3.back, player.position - tr.position + noise);

                Vector3 spawn = tr.position + (tr.rotation * Vector3.up);
                Instantiate(bullet, spawn, tr.rotation);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
