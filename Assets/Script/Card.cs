using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Card : ScriptableObject
{
    public int CardID;
    public string CardName;
    public CardSprite sprite;
    public string cardDialogue;
    public string leftDialogue;
    public string RightDialogue;
    public void Left()
    {
        Debug.Log(CardName + " swipe left");
    }

    public void Right()
    {
        Debug.Log(CardName + " swipe right");
    }
}
