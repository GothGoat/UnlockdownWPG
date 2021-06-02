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
        if (!GameLogic.iskarmaBad)
        {
            GameLogic.Health += health_left / 100f;
            GameLogic.Mental += mental_left / 100f;
            GameLogic.Money += money_left / 100f;
        }
        else if (GameLogic.iskarmaBad)
        {
            GameLogic.Health += Karma.badDebuff / 100f;
            GameLogic.Mental += Karma.badDebuff  / 100f;
            GameLogic.Money += Karma.badDebuff / 100f;

        }
        if (karma)
        { 
            GameLogic.iskarmaBad = true;
            Debug.Log("Bad Activate");
        }
    }

    public void Right()
    {
        if (!GameLogic.iskarmaBad)
        {
            GameLogic.Health += health_right / 100f;
            GameLogic.Mental += mental_right / 100f;
            GameLogic.Money += money_right / 100f;
        }
        else if (GameLogic.iskarmaBad)
        {
            GameLogic.Health += Karma.badDebuff / 100f;
            GameLogic.Mental += Karma.badDebuff / 100f;
            GameLogic.Money += Karma.badDebuff / 100f;
        }

        if (karma)
            GameLogic.iskarmaGood = true;
    }

}
