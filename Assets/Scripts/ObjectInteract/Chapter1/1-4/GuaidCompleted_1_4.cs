using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuaidCompleted_1_4 : MonoBehaviour
{
    // Start is called before the first frame update
    public CardScript card1;
    public CardScript card2;
    public CardScript card3;
    public GameObject timeline;
    // Update is called once per frame
    void Update()
    {
        if(card1.Choosen&&card2.Choosen&&card3.Choosen)
        {
            //选完初始三张卡片
            timeline.SetActive(true);
        }
    }
}
