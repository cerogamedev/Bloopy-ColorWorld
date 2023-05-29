using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChange : MonoBehaviour
{
    public string _tag = "Platform";
    private int renkIndex = 0; 
    private Color[] renkler = { Color.yellow, Color.blue, Color.magenta, Color.red };
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_tag))
        {
            ColorChange();
        }
    }
    void Update()
    {
        
    }
    void ColorChange()
    {
        renkIndex = (renkIndex + 1) % renkler.Length;
        GameObject colorIndex = GameObject.FindGameObjectWithTag("ColorIndex");
        colorIndex.transform.GetComponent<SpriteRenderer>().color = renkler[renkIndex];
    }
}
