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
    public float mental_left;
    public float health_left;
    public float money_left;
    public float mental_right;
    public float health_right;
    public float money_right;
}
