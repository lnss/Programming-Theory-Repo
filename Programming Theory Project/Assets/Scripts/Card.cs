using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class Card : MonoBehaviour
{
    public TextMeshProUGUI numText;

    //ENCAPSULASION
    public int numInt { get; private set; }

    private int scoreToAdd = 50;
    private int upperBound = 10;
    private int lowerBound = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        //ABSTRACTION
        RandomNumberGenerate(lowerBound, upperBound);
        
    }


    // Randomly generate a number for this card.
    public void RandomNumberGenerate(int min, int max)
    {
        numInt = Random.Range(min, max);
        numText.text = numInt.ToString();
    }


    public void BeClicked()
    {
        if(gameObject.CompareTag("NotSelected"))
        {
            GameManager.cardSelected.Add(gameObject);
            GameManager.resultNum += numInt;
            gameObject.tag = "Selected";
        }

        MatchResult();

    }


    public void MatchResult()
    {
        if(GameManager.cardSelected.Count == 2)
        {
            if (GameManager.resultNum == GameManager.goalNum)
            {
                RightMatch();
            }
            else
            {
                WrongMatch();
            }
        }
        
    }

    //POLYMORPHISM
    public virtual void RightMatch()
    {
        GameManager.score += scoreToAdd;
        Destroy(GameManager.cardSelected[0]);
        Destroy(GameManager.cardSelected[1]);
        GameManager.cardSelected.Clear();
        GameManager.resultNum = 0;
    }


    public void WrongMatch()
    {
        GameManager.life--;
        GameManager.cardSelected[0].tag = "NotSelected";
        GameManager.cardSelected[1].tag = "NotSelected";
        GameManager.cardSelected.Clear();
        GameManager.resultNum = 0;

    }


}
