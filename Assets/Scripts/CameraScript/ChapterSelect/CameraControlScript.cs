using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControlScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool moving;
    public float moveSpeed;
    private Vector3 target;
    

    private void Start()
    {
        moving = false;
        target = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.target, Time.deltaTime * moveSpeed);
            ClickFlag.GetInstance().CanClick = false;//相机运动过程中，无法点击章节选择
            if (Vector3.Distance(transform.position, target) < 0.001f)
            {
                // Swap the position of the cylinder.
                moving = false;
                ClickFlag.GetInstance().CanClick = true;//相机运动结束后才能点击章节选择
            }
        }
    }
    public void cameraMove(Vector3 target)
    {
        this.target = new Vector3(target.x,target.y,this.target.z);
        moving = true;
        //Debug.Log("move" + target + moving);
    }

}
