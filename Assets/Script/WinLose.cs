using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    GameLogic GL;
    public Karma karma;

    // Win
    public Card healthWin;
    public Card mentalWin;
    public Card moneyWin;

    // Lose
    public Card healthLose;
    public Card mentalLose;
    public Card moneyLose;

    public static bool GameOver;
    void Awake()
    {
        GL = GameObject.Find("GameManager").GetComponent<GameLogic>();
    }

    void Start()
    {
        GameOver = false;
    }

    void Update()
    {
        if (GL.month_count > 36)
        {
            Win();
            GameOver = true;
        }
        else if (GameLogic.Health <= 0 || GameLogic.Mental <= 0 || GameLogic.Money <= 0)
        {
            Lose();
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
            GameLogic.Health += 0.5f;
            GameLogic.Mental += 0.5f;
            GameLogic.Money += 0.5f;
            GameLogic.iskarmaGood = false;
            karma.Impact();
        }
        else
        {
            Debug.Log("You Lose");
            GameOver = true;
            if (GameLogic.Mental <= 0.005f)
            {
                GL.currentCard = mentalLose;
                GL.CardSpriteRenderer.sprite = mentalLose.sprite;
                GL.leftdialogue = mentalLose.leftDialogue;
                GL.rightdialogue = mentalLose.RightDialogue;
                GL.carddialoguetext.text = mentalLose.cardDialogue;
            }
            else if (GameLogic.Money <= 0.005f)
            {
                GL.currentCard = moneyLose;
                GL.CardSpriteRenderer.sprite = moneyLose.sprite;
                GL.leftdialogue = moneyLose.leftDialogue;
                GL.rightdialogue = moneyLose.RightDialogue;
                GL.carddialoguetext.text = moneyLose.cardDialogue;
            }
            else if (GameLogic.Health <= 0.005f)
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
