using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHandler : MonoBehaviour
{
    public static PuzzleHandler Instance;

    public PuzzleMatchemScript firstCard;
    bool setFirstCard;
    public PuzzleMatchemScript secondCard;
    bool setSecondCard;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance) Destroy(this);
        Instance = this;
        setFirstCard = false;
        setSecondCard = false;
    }

    public void ResetValues()
    {
        firstCard.GetComponent<Renderer>().material.color = firstCard.GetComponent<PuzzleMatchemScript>().defaultColorValue;
        secondCard.GetComponent<Renderer>().material.color = secondCard.GetComponent<PuzzleMatchemScript>().defaultColorValue;
        setSecondCard = setFirstCard = false;
        firstCard = secondCard = null;
    }

    public void CheckValue()
    {
        if(firstCard.value == secondCard.value)
        {
            firstCard.gameObject.SetActive(false);
            secondCard.gameObject.SetActive(false);
        }

        ResetValues();

    }

    public void SetValue(PuzzleMatchemScript card)
    {
        if (firstCard == card)
        {
            print("wtf");
            return;
        }
        print("bruh");
        if(!setFirstCard)
        {
            firstCard = card;
            setFirstCard = true;

            card.GetComponent<Renderer>().material.color = card.colorValue;
        }else if(setFirstCard && !setSecondCard)
        {

            secondCard = card;
            setSecondCard = true;
            card.GetComponent<Renderer>().material.color = card.colorValue;

            CheckValue();
        }

    }
    
}
