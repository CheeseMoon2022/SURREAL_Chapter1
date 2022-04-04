using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int[] choosen;
    [SerializeField]
    private int[] cardState = {0,1,2,0,1,2,0,1,2};
    public GameObject cardPrefab;
    private int instIndex = 0;//记录当前生成数；
    public Transform[] pos;
    public GameObject[] end;//0-积极，1-普通，2-消极；
    public Sprite[] posSprite;
    public Sprite[] norSprite;
    public Sprite[] negSprite;
    private int posIndex = 0;
    private int norIndex = 0;
    private int negIndex = 0;
    public int[] Choosen
    {
        get
        {
            return choosen;
        }
        set
        {
            choosen = value;
        }
    }

    // Update is called once per frame

    public void cardInstantiate()
    {
        GameObject card = Instantiate(cardPrefab, pos[instIndex].position,pos[instIndex].rotation,transform.GetChild(2).transform);
        card.GetComponent<CardScript>().CardStyle = getNextCard();
        card.GetComponent<CardScript>().cardManager = this;
        instIndex++;
    }

    int getNextCard()
    {
        //func1:
        /*
        int nextCard = 1;
        int chooseMax = Mathf.Max(choosen[0], choosen[1], choosen[2]);
        if(choosen[0] == choosen[1] && choosen[0] == choosen[2])
        {
            nextCard = Random.Range(0, 2);
        }
        else if(choosen[0] == choosen[1] && choosen[0] > choosen[2])
        {
            nextCard = Random.Range(0, 1);
        }
        else if (choosen[0] == choosen[2] && choosen[0] > choosen[1])
        {
            nextCard = Random.Range(0, 1) == 1 ? 0 : 2;
        }else if(choosen[1] == choosen[2] && choosen[1]>choosen[0])
        {
            nextCard = Random.Range(1, 2);
        }
        else if (choosen[0] == chooseMax)
        {
            nextCard = 0;
        }
        else if(choosen[1] == chooseMax)
        {
            nextCard = 1;
        }
        else if (choosen[2] == chooseMax)
        {
            nextCard = 2;
        }
        return nextCard;
        */
        //func2:
        int randomIndex = Random.Range(0, cardState.Length - 1);
        //Debug.Log(randomIndex);
        return cardState[randomIndex];
    }

    public void cardStateLike(int state)
    {
        for (int i = 0;i<cardState.Length-1;i++)
        {
            cardState[i] = cardState[i + 1];
        }
        cardState[cardState.Length - 1] = state;
    }

    public void cardStateDislike(int state)
    {
        for (int i = cardState.Length-1; i >= 0 ; i--)
        {
            if (cardState[i] == state)
            {
                switch(state)
                {
                    case 0:
                        cardState[i] = choosen[1]>= choosen[2] ? 1 : 2;
                        break;
                    case 1:
                        cardState[i] = choosen[0] >= choosen[2] ? 0 : 2;
                        break;
                    case 2:
                        cardState[i] = choosen[0] >= choosen[1] ? 0 : 1;
                        break;
                }
                break;
            }
        }
    }

    public Sprite randomCardBg(int cardStyle)
    {
        Sprite bg = null;
        //根据卡片的类型赋予其显示内容；
        switch(cardStyle)
        {
            case 0:
                //pos
                bg = randomSprite(posSprite, ref posIndex);
                break;
            case 1:
                //nor
                bg = randomSprite(norSprite, ref norIndex);
                break;
            case 2:
                //neg
                bg = randomSprite(negSprite, ref negIndex);
                break;
        }
        return bg;
    }

    Sprite randomSprite(Sprite[] sprite,ref int index)
    {
        //随机获取卡片内容，尽量不重复
        if (index >= sprite.Length)
        {
            //取完了
            return sprite[Random.Range(0,sprite.Length-1)];
        }
        int randomIndex = Random.Range(0, sprite.Length - 1 - index);
        Sprite temp = sprite[randomIndex];
        sprite[randomIndex] = sprite[sprite.Length - 1 - index];
        sprite[sprite.Length - 1 - index] = temp;
        index ++;
        return temp;
    }


    public void toEnd()
    {
        int chooseMax = Mathf.Max(choosen[0], choosen[1], choosen[2]);
        if (choosen[0] == chooseMax)
        {
            //积极结局
            end[0].SetActive(true);
            return;
        }
        if (choosen[1] == chooseMax)
        {
            //普通结局
            end[1].SetActive(true);
            return;
        }
        if (choosen[2] == chooseMax)
        {
            //普通结局
            end[2].SetActive(true);
            return;
        }
    }

}
