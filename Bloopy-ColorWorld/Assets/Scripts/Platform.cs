using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Color[] renkler = { Color.yellow, Color.blue, Color.magenta, Color.red };
    private bool isOkey;
    void Start()
    {
        GetComponent<SpriteRenderer>().color = renkler[Random.Range(0, renkler.Length)];
        isOkey = false;
    }

    void Update()
    {
        GameObject colorIndex = GameObject.FindGameObjectWithTag("ColorIndex");

        if (isOkey == false)
        {
            if (colorIndex.GetComponent<SpriteRenderer>().color == this.GetComponent<SpriteRenderer>().color)
            {
                this.transform.tag = "Platform";
            }
            else
                this.transform.tag = "Untagged";
        }
        else
            return;
    }
    private void FixedUpdate()
    {
        
        if (this.tag == "Platform")
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
            GetComponent<BoxCollider2D>().enabled = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && this.tag == "Platform")
        {
            StabilePlatform();
        }
    }
    void StabilePlatform()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
        GetComponent<BoxCollider2D>().enabled = true;
        this.tag = "Platform";
        isOkey = true;

    }

}
