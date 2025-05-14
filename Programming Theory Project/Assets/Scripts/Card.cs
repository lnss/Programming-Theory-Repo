using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class Card : MonoBehaviour
{
    public TextMeshProUGUI numText;

    private int scoreToAdd = 50;
    private int numInt;
    private int upperBound = 60;
    private int lowerBound = 1;

    [SerializeField] private bool isSelected = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //ABSTRACTION
        RandomNumberGenerate(lowerBound, upperBound);

    }

    private void Update()
    {
        MatchResult();
    }

    // Randomly generate a number for this card.
    public void RandomNumberGenerate(int min, int max)
    {
        numInt = Random.Range(min, max);
        numText.text = numInt.ToString();
    }


    public void BeClicked()
    {
        if (!isSelected)
        {
            GameManager.cardSelectedNum += 1;
            GameManager.resultNum += numInt;
            
            isSelected = true;
        }
        
    }


    public void MatchResult()
    {
        if(GameManager.cardSelectedNum == 2)
        {
            if (GameManager.resultNum == GameManager.goalNum)
            {
                RightMatch();
            }
            else
            {
                WrongMatch();
            }
            EventSystem.current.SetSelectedGameObject(null);
            GameManager.cardSelectedNum = 0;
            GameManager.resultNum = 0;
            isSelected = false;
        }
        
    }

    
    public virtual void RightMatch()
    {
        GameManager.score += scoreToAdd;

    }

    public virtual void WrongMatch()
    {
        GameManager.life -= 1;

    }


}
