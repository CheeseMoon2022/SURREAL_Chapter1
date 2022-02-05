using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GuidanceEyeEvent: MonoBehaviour
{
    // Start is called before the first frame update
    public float waitTime;
    public float dropTime;
    public GameObject dropPoint;
    public Animator anim;
    public Camera camera;

    private SpriteRenderer rd;

    void Start()
    {
        rd = this.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartAnim()
    {
        rd.transform.DOMove(dropPoint.transform.position, dropTime);
    }

    void OnMouseDown()
    {
        anim.SetBool("isClicked", true);
        Invoke("StartAnim", waitTime);
        //Ïà»úÇÐ»»µ½×´Ì¬2
        camera.GetComponent<CameraControlScript>().stage = 2;
    }

}
