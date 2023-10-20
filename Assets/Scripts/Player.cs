using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Transform tr;
    public GameObject bullet;

    public float maxSpeed = 10.0f;
    public float acc = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        tr = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        float speed = Mathf.Min((rb.velocity + (direction * acc)).magnitude, maxSpeed);
        rb.velocity = direction * speed;

        if (direction != Vector2.zero)
        {
            tr.rotation = Quaternion.LookRotation(Vector3.back, direction);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 spawn = tr.position + (tr.rotation * Vector3.up);
            Instantiate(bullet, spawn, tr.rotation);
        }
    }

    void OnDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
