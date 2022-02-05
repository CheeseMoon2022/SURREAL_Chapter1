using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraControlScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float entryTime;
    public Transform eye;
    public int stage = 1;
    public float targetFieldOfView;
    public float smoothTime;
    public float smoothWaitTime;
    private float smoothVelocity;


    private void Start()
    {
        transform.DOMove(new Vector3(0,0,-10f), entryTime);
    }

    void smoothCloser()
    {

        Camera.main.fieldOfView = Mathf.SmoothDamp(Camera.main.fieldOfView, targetFieldOfView, ref smoothVelocity, smoothTime);
    }


    
    // Update is called once per frame
    void Update()
    {
        if(stage == 2)
        {
            this.transform.position = new Vector3(eye.position.x, eye.position.y, -10f);
            Invoke("smoothCloser",smoothWaitTime);
            
        }
    }
}
