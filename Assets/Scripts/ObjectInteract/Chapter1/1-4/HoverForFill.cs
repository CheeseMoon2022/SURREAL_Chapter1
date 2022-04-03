using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverForFill : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer fillRd;
    public Animation anim;
    private bool isFilled;
    public int state;//0,1,2
    public float speed;
    public float heightMax;
    public float timeMax;
    private float deltaTime = 0.0f;
    public bool IsFilled
    {
        get
        {
            return isFilled;
        }
        set
        {
            isFilled = value;
        }
    }

    private void Start()
    {
        isFilled = false;
        state = 0;
    }

    private void Update()
    {
        if(state == 1)
        {
            //填充下降
            //Debug.Log(fillRd.size);
            fillRd.size = Vector2.Lerp(fillRd.size, new Vector2(fillRd.size.x, 0), Time.deltaTime/(timeMax - deltaTime) * speed);
            deltaTime += Time.deltaTime;
            //Debug.Log("1:"+deltaTime);
            if (fillRd.size.y < 0.05f)
            {
                state = 0;
                isFilled = true;
                anim.Play("Thumb_Filled",PlayMode.StopAll);
            }
        }
        if(state == 2)
        {
            //上升
            fillRd.size = Vector2.Lerp(fillRd.size, new Vector2(fillRd.size.x, heightMax), Time.deltaTime/(timeMax - deltaTime) * speed);
            deltaTime += Time.deltaTime;
            //Debug.Log("2:"+deltaTime);
            if (fillRd.size.y >= heightMax - 0.05f)
            {
                state = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isFilled)
        {
            if (collision.tag == "Player")
            {
                anim.Play("Thumb_Filling");
                state = 1;
                deltaTime = 0.0f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isFilled)
        {
            if (collision.tag == "Player")
            {
                anim.Stop();
                state = 2;
                deltaTime = 0.0f;
            }
        }
    }
}
