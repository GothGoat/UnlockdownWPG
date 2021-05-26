using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLogic : MonoBehaviour
{
    public Card card;
    public bool isMouseOver = false;
    private void OnMouseOver()
    {
        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }
}

public enum CardSprite
{
    ONE,
    TWO,
    THREE,
}
