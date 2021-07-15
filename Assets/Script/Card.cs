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
    public float gKarma_left;
    public float bKarma_left;

    public float mental_right;
    public float health_right;
    public float money_right;
    public float gKarma_right;
    public float bKarma_right;

    public void Left()
    {
        if (GameLogic.bad_karma <= 0)
        {
            GameLogic.Health += health_left / 100f;
            GameLogic.Mental += mental_left / 100f;
            GameLogic.Money += money_left / 100f;

            if (GameLogic.total_karma < 4)  // If not full 
            {
                GameLogic.good_karma += gKarma_left;
                GameLogic.bad_karma += bKarma_left;
            }
        }
        else if (GameLogic.bad_karma > 0)
        {
            GameLogic.Health += KarmaUI.badDebuff / 100f;
            GameLogic.Mental += KarmaUI.badDebuff  / 100f;
            GameLogic.Money += KarmaUI.badDebuff / 100f;

            if (GameLogic.total_karma < 4)  // If not full 
            {
                GameLogic.good_karma += gKarma_left;
                GameLogic.bad_karma += bKarma_left;
            }

            // remove icon
            GameLogic.bad_karma--;

        }

        GameLogic.total_karma = GameLogic.bad_karma + GameLogic.good_karma;
    }

    public void Right()
    {
        if (GameLogic.bad_karma <= 0)
        {
            GameLogic.Health += health_right / 100f;
            GameLogic.Mental += mental_right / 100f;
            GameLogic.Money += money_right / 100f;

            if (GameLogic.total_karma < 4)  // If not full 
            {
                GameLogic.good_karma += gKarma_right;
                GameLogic.bad_karma += bKarma_right;
            }
        }
        else if (GameLogic.bad_karma > 0)
        {
            GameLogic.Health += KarmaUI.badDebuff / 100f;
            GameLogic.Mental += KarmaUI.badDebuff / 100f;
            GameLogic.Money += KarmaUI.badDebuff / 100f;

            if (GameLogic.total_karma < 4)  // If not full 
            {
                GameLogic.good_karma += gKarma_right;
                GameLogic.bad_karma += bKarma_right;
            }

            // Remove bad karma icon Here
            GameLogic.bad_karma--;
        }

        GameLogic.total_karma = GameLogic.bad_karma + GameLogic.good_karma;
    }

}
