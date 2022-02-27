using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidanceEyeEvent: MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public GameObject fallingTimeline;
    void Start()
    {
        if (!anim)
        {
            //anim = this.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        anim.SetBool("isHover", true);
    }

    private void OnMouseExit()
    {
        anim.SetBool("isHover", false);
    }

    void OnMouseDown()
    {
        anim.SetBool("isClicked", true);
        fallingTimeline.SetActive(true);
    }

}
