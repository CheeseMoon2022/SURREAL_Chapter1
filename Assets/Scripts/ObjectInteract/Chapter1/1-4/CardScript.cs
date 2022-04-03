using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    // Start is called before the first frame update
    public CardManagerScript cardManager;
    public HoverForFill like;
    public HoverForFill dislike;
    public SpriteRenderer background;
    public Rope rope;

    private bool choosen = false;
    public bool Choosen
    {
        get
        {
            return choosen;
        }
    }
    [SerializeField]
    [Range(0,2)]
    private int cardStyle;//0-积极、1-中性、2-消极
    public int CardStyle
    {
        get
        {
            return cardStyle;
        }
        set
        {
            cardStyle = value;
        }
    }

    private void Start()
    {
        //Debug.Log(cardStyle);
        background.sprite = cardManager.randomCardBg(cardStyle);
    }
    // Update is called once per frame
    void Update()
    {
        if(!choosen)
        {
            if (like.IsFilled)
            {
                rope.ropeBreak();
                cardManager.Choosen[cardStyle] += 1;
                cardManager.cardStateLike(cardStyle);
                choosen = true;
            }
            else if (dislike.IsFilled)
            {
                rope.ropeBreak();
                cardManager.Choosen[cardStyle] -= 1;
                cardManager.cardStateDislike(cardStyle);
                choosen = true;
            }
        }
    }
}
