using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public string _tag = "Platform"; 
    public float bouncePower = 10f;
    public float speed = 5f;

    private Animator anim;
    private Rigidbody2D rb;
    private float minX, maxX;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        float uzaklikKameraVeObjeArasi = transform.position.z - Camera.main.transform.position.z;
        Vector3 solSinirNoktasi = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, uzaklikKameraVeObjeArasi));
        Vector3 sagSinirNoktasi = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, uzaklikKameraVeObjeArasi));

        minX = solSinirNoktasi.x;
        maxX = sagSinirNoktasi.x;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_tag))
        {
            ThrowUp();
        }
    }

    void ThrowUp()
    {
        rb.velocity = new Vector2(rb.velocity.x, bouncePower);
    }
    private void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        if (movement > 0)
            GetComponent<SpriteRenderer>().flipX = enabled;
        else if (movement < 0)
            GetComponent<SpriteRenderer>().flipX = !enabled;



        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        if (rb.velocity.y > .1f)
            anim.SetInteger("state", 1);
        else if (rb.velocity.y <-.1f )
            anim.SetInteger("state", 2);



        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
