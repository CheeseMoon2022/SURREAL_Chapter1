using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public int state = 1;//1-固定绳长；2-随机范围绳长
    public Rigidbody2D hook;
    public GameObject linkPrefab;
    
    public HingeJoint2D cardJoint;
    public int links;
    public int linkMin;
    public int linkMax;
    private GameObject breakOne;
    // Start is called before the first frame update
    void Start()
    {
        if (state == 2)
        {
            links = Random.Range(linkMin, linkMax);
            //Debug.Log(links);
        }
        ropeLink();
    }

    public void ropeLink()
    {
        Rigidbody2D preRB = hook;
        for(int i=0;i<links;i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = preRB;
            preRB = joint.GetComponent<Rigidbody2D>();
        }
        cardJoint.connectedBody = preRB;
    }

    public void ropeBreak()
    {
        int index = Random.Range(4, links - 2);
        //Debug.Log(index);
        breakOne = transform.GetChild(index).gameObject;
        //Debug.Log(breakOne);
        Invoke("linkAddForce", 0.25f);
        Invoke("linkSetActive", 1);
    }
    private void linkAddForce()
    {
        breakOne.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 0));
    }
    private void linkSetActive()
    {
       breakOne.SetActive(false);
    }
    
}
