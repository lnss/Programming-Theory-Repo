using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Card : MonoBehaviour
{
    public TextMeshProUGUI numText;
    
    private int numInt;
    private int goal = 60;
    
    // Start is called before the first frame update
    void Start()
    {
        numInt = RandomNumberGenerate(goal);
        numText.text = numInt.ToString();
    }

    int RandomNumberGenerate(int upperbound)
    {
        return Random.Range(0, upperbound+1);
    }

    


}
