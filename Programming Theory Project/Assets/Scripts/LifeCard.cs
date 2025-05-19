using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class LifeCard : Card
{
    private int lifeToAdd = 1;

    public override void RightMatch()
    {
        GameManager.life += lifeToAdd;
        base.RightMatch();
    }
}
