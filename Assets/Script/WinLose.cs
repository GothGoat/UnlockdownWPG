using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    GameLogic GL;
    // Win
    public Card healthWin;
    public Card mentalWin;
    public Card moneyWin;

    // Lose
    public Card healthLose;
    public Card mentalLose;
    public Card moneyLose;

    public static bool GameOver = false;
    void Awake()
    {
        GL = GameObject.Find("GameManager").GetComponent<GameLogic>();
    }

    void Update()
    {
        if (GL.month_count > 15)
        {
            Win();
            GameOver = true;
        }
        else if (GameLogic.Health <= 0 || GameLogic.Mental <= 0 || GameLogic.Money <= 0)
        {
            Lose();
            GameOver = true;
        }
    }

    void Win()
    {
        Debug.Log("You Win");
        if (GameLogic.Health > GameLogic.Money && GameLogic.Health > GameLogic.Mental)
        {
            GL.currentCard = healthWin;
            GL.CardSpriteRenderer.sprite = healthWin.sprite;
            GL.leftdialogue = healthWin.leftDialogue;
            GL.rightdialogue = healthWin.RightDialogue;
            GL.carddialoguetext.text = healthWin.cardDialogue;

            if (GL.card.transform.position.x < -GL.fsidemargin)   // Left
            {
                GL.dialogue.text = GL.leftdialogue;
                GL.dialogue.alpha = Mathf.Min(-GL.card.transform.position.x, 1);
                GL.dialogue_box.CrossFadeAlpha(1, 0.1f, true);
                if (Input.GetMouseButtonUp(0))
                {
                    // Back To Main Menu
                }
            }
            else if (GL.card.transform.position.x > GL.fsidemargin)   // Right
            {
                GL.dialogue.text = GL.rightdialogue;
                GL.dialogue.alpha = Mathf.Min(GL.card.transform.position.x, 1);
                GL.dialogue_box.CrossFadeAlpha(1, 0.1f, true);
                if (Input.GetMouseButtonUp(0))
                {
                    // Play Again
                }
            }
        }
        else if (GameLogic.Money > GameLogic.Health && GameLogic.Money > GameLogic.Mental)
        {
            GL.currentCard = moneyWin;
            GL.CardSpriteRenderer.sprite = moneyWin.sprite;
            GL.leftdialogue = moneyWin.leftDialogue;
            GL.rightdialogue = moneyWin.RightDialogue;
            GL.carddialoguetext.text = moneyWin.cardDialogue;
        }
        else if (GameLogic.Mental > GameLogic.Health && GameLogic.Mental > GameLogic.Money)
        {
            GL.currentCard = mentalWin;
            GL.CardSpriteRenderer.sprite = mentalWin.sprite;
            GL.leftdialogue = mentalWin.leftDialogue;
            GL.rightdialogue = mentalWin.RightDialogue;
            GL.carddialoguetext.text = mentalWin.cardDialogue;
        }
    }

    void Lose()
    {
        if (GameLogic.iskarmaGood) // Karma Good Impact
        {
            GameLogic.Health += 2;
            GameLogic.Mental += 20;
            GameLogic.Money += 20;
            GameLogic.iskarmaGood = false;
        }
        else
        {
            Debug.Log("You Lose");
            if (GameLogic.Mental <= 0)
            {
                GL.currentCard = mentalLose;
                GL.CardSpriteRenderer.sprite = mentalLose.sprite;
                GL.leftdialogue = mentalLose.leftDialogue;
                GL.rightdialogue = mentalLose.RightDialogue;
                GL.carddialoguetext.text = mentalLose.cardDialogue;
            }
            else if (GameLogic.Health <= 0)
            {
                GL.currentCard = healthLose;
                GL.CardSpriteRenderer.sprite = healthLose.sprite;
                GL.leftdialogue = healthLose.leftDialogue;
                GL.rightdialogue = healthLose.RightDialogue;
                GL.carddialoguetext.text = healthLose.cardDialogue;
            }
            else if (GameLogic.Health <= 0)
            {
                GL.currentCard = healthLose;
                GL.CardSpriteRenderer.sprite = healthLose.sprite;
                GL.leftdialogue = healthLose.leftDialogue;
                GL.rightdialogue = healthLose.RightDialogue;
                GL.carddialoguetext.text = healthLose.cardDialogue;
            }
        }
    }
}
