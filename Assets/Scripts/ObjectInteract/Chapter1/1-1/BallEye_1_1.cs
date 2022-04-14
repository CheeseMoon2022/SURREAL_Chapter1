using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEye_1_1 : MonoBehaviour
{
    // Start is called before the first frame update
    //public float radios;
    public Rigidbody2D rb;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(rb.position);
        rb.velocity = (mousePos - rb.position) * speed;
    }
}
