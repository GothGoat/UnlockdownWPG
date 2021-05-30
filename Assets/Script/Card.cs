using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Card : ScriptableObject
{
    public int CardID;
    public string CardName;
    public Sprite sprite;
    public string cardDialogue;
    public string leftDialogue;
    public string RightDialogue;
    
    // Parameter
    public int mental_left;
    public int health_left;
    public int money_left;

    public int mental_right;
    public int health_right;
    public int money_right;
}
