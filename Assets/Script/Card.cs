using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Card : ScriptableObject
{
    public string CardName;
    public Sprite sprite;
    public string cardDialogue;
    public string leftDialogue;
    public string RightDialogue;
    public bool karma;
    
    // Parameter
    public float mental_left;
    public float health_left;
    public float money_left;

    public float mental_right;
    public float health_right;
    public float money_right;

    public void Left()
    {
        GameLogic.Health += health_left / 100f;
        GameLogic.Mental += mental_left / 100f;
        GameLogic.Money += money_left / 100f;

        if (karma)
            GameLogic.iskarmaBad = true;
    }

    public void Right()
    {
        GameLogic.Health += health_right / 100f;
        GameLogic.Mental += mental_right / 100f;
        GameLogic.Money += money_right / 100f;

        if (karma)
            GameLogic.iskarmaGood = true;
    }

}
