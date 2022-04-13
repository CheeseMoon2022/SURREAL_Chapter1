using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OvenDetect : MonoBehaviour
{
    public GameObject chicken, leftDoor, rightDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject);
        if (collision.gameObject == chicken)
        {
            //检测到鸡时
            //Debug.Log(2);
            ovenOpen();
            chicken.GetComponent<ChickenDrag>().Fit = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //鸡离开时
        if (collision.gameObject == chicken)
        {
            ovenClose();
            chicken.GetComponent<ChickenDrag>().Fit = false;
        }

    }

    public void ovenOpen()
    {
        leftDoor.transform.DORotate(new Vector3(0, 180, 0), 1);
        rightDoor.transform.DORotate(new Vector3(0, 180, 0), 1);
    }

    public void ovenClose()
    {
        leftDoor.transform.DORotate(new Vector3(0, 0, 0), 1);
        rightDoor.transform.DORotate(new Vector3(0, 0, 0), 1);
    }




}
